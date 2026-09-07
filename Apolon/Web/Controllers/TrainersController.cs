using System.Security.Claims;
using Apolon.Common;
using Apolon.Data.Data;
using Apolon.Data.Models;
using Apolon.Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Apolon.Controllers;

public class TrainersController : Controller
{
    private readonly ApplicationDbContext context;

    public TrainersController(ApplicationDbContext _context)
    {
        this.context = _context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Trainer> trainers = await context.Trainers.ToListAsync();
        return View(trainers);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Book(Guid trainerId)
    {
        Trainer? trainer = await context.Trainers.FindAsync(trainerId);

        if (trainer is null)
        {
            return RedirectToAction(nameof(Index));
        }

        BookTrainerViewModel model = await CreateBookingModel(trainer, DateOnly.FromDateTime(DateTime.Today.AddDays(1)));

        return View(model);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Book(BookTrainerViewModel model)
    {
        Trainer? trainer = await context.Trainers.FindAsync(model.TrainerId);
        if (trainer is null)
        {
            return NotFound();
        }

        model.TrainerName = $"{trainer.FirstName} {trainer.LastName}";
        model.TrainerImageUrl = trainer.ImageUrl;
        model.AvailableTimes = await GetAvailableTimes(trainer.TrainerId, model.BookingDate);

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string? userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            return Challenge();
        }

        if (!model.AvailableTimes.Contains(model.BookingTime))
        {
            ModelState.AddModelError(nameof(model.BookingTime),
                ModelConstants.BookSession.BookingTimeUnavailableErrorMessage);
            return View(model);
        }

        Session session = new Session()
        {
            TrainerId = model.TrainerId,
            UserId = userId,
            BookingDate = model.BookingDate,
            BookingTime = model.BookingTime,
            Notes = model.Notes
        };

        try
        {
            await context.Sessions.AddAsync(session);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            ModelState.AddModelError(nameof(model.BookingTime),
                ModelConstants.BookSession.BookingTimeUnavailableErrorMessage);
            return View(model);
        }

        TempData["SuccessMessage"] =
            $"Successfully booked a session with {model.TrainerName} on {model.BookingDate:d} at {model.BookingTime:HH\\:mm}.";
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> AvailableTimes(Guid trainerId, DateOnly date)
    {
        if (!await context.Trainers.AnyAsync(t => t.TrainerId == trainerId))
        {
            return NotFound();
        }

        return Json((await GetAvailableTimes(trainerId, date))
            .Select(time => time.ToString("HH\\:mm")));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Reschedule(Guid sessionId)
    {
        if (!TryGetUserId(out Guid userId))
        {
            return Challenge();
        }

        Session? session = await context.Sessions
            .Include(s => s.Trainer)
            .SingleOrDefaultAsync(s => s.SessionId == sessionId && s.UserId == userId);
        if (session is null)
        {
            return NotFound();
        }

        BookTrainerViewModel model = await CreateBookingModel(session.Trainer, session.BookingDate);
        model.SessionId = session.SessionId;
        model.BookingTime = session.BookingTime;
        model.Notes = session.Notes;
        model.AvailableTimes = (await GetAvailableTimes(session.TrainerId, session.BookingDate, session.SessionId))
            .Append(session.BookingTime)
            .OrderBy(time => time)
            .ToArray();

        return View("Book", model);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reschedule(Guid sessionId, BookTrainerViewModel model)
    {
        if (!TryGetUserId(out Guid userId))
        {
            return Challenge();
        }

        Session? session = await context.Sessions
            .Include(s => s.Trainer)
            .SingleOrDefaultAsync(s => s.SessionId == sessionId && s.UserId == userId);
        if (session is null)
        {
            return NotFound();
        }

        model.SessionId = session.SessionId;
        model.TrainerId = session.TrainerId;
        model.TrainerName = $"{session.Trainer.FirstName} {session.Trainer.LastName}";
        model.TrainerImageUrl = session.Trainer.ImageUrl;
        model.AvailableTimes = await GetAvailableTimes(session.TrainerId, model.BookingDate, session.SessionId);

        if (!ModelState.IsValid || !model.AvailableTimes.Contains(model.BookingTime))
        {
            if (!ModelState.IsValid)
            {
                return View("Book", model);
            }

            ModelState.AddModelError(nameof(model.BookingTime),
                ModelConstants.BookSession.BookingTimeUnavailableErrorMessage);
            return View("Book", model);
        }

        session.BookingDate = model.BookingDate;
        session.BookingTime = model.BookingTime;
        session.Notes = model.Notes;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            ModelState.AddModelError(nameof(model.BookingTime),
                ModelConstants.BookSession.BookingTimeUnavailableErrorMessage);
            return View("Book", model);
        }

        TempData["SuccessMessage"] = "Your session was rescheduled successfully.";
        return RedirectToAction("Index", "Account");
    }

    private async Task<BookTrainerViewModel> CreateBookingModel(Trainer trainer, DateOnly date)
    {
        return new BookTrainerViewModel
        {
            TrainerId = trainer.TrainerId,
            TrainerName = $"{trainer.FirstName} {trainer.LastName}",
            TrainerImageUrl = trainer.ImageUrl,
            BookingDate = date,
            AvailableTimes = await GetAvailableTimes(trainer.TrainerId, date)
        };
    }

    private async Task<IReadOnlyCollection<TimeOnly>> GetAvailableTimes(
        Guid trainerId, DateOnly date, Guid? excludedSessionId = null)
    {
        var openingTime = new TimeOnly(ModelConstants.BookSession.OpeningHour, 0);
        var closingTime = new TimeOnly(ModelConstants.BookSession.ClosingHour, 0);
        var bookedTimes = await context.Sessions
            .Where(s => s.TrainerId == trainerId && s.BookingDate == date &&
                        (!excludedSessionId.HasValue || s.SessionId != excludedSessionId.Value))
            .Select(s => s.BookingTime)
            .ToListAsync();

        var slotCount = (ModelConstants.BookSession.ClosingHour -
                         ModelConstants.BookSession.OpeningHour) * 60 /
                        ModelConstants.BookSession.SessionDurationMinutes;

        return Enumerable.Range(0, slotCount)
            .Select(offset => openingTime.AddMinutes(
                offset * ModelConstants.BookSession.SessionDurationMinutes))
            .Where(time => time < closingTime && !bookedTimes.Contains(time))
            .ToArray();
    }

    private bool TryGetUserId(out Guid userId)
    {
        return Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId);
    }
}