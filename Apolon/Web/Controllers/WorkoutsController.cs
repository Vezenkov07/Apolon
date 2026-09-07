using Apolon.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Controllers;

public class WorkoutsController : Controller
{
    private readonly ApplicationDbContext context;

    public WorkoutsController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var workouts = await context.Workouts
            .Include(w => w.Split)
            .Include(w => w.Trainer)
            .OrderBy(w => w.StartTime)
            .ToListAsync();

        return View(workouts);
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var workout = await context.Workouts
            .Include(w => w.Split)
            .Include(w => w.Trainer)
            .SingleOrDefaultAsync(w => w.WorkoutId == id);

        return workout is null ? NotFound() : View(workout);
    }
}
