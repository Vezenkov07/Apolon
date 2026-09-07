using Apolon.Data.Data;
using Apolon.Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Controllers;

public class SupplementsController : Controller
{
    private readonly ApplicationDbContext context;

    public SupplementsController(ApplicationDbContext _context)
    {
        this.context = _context;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string? query, string? sortOrder)
    {
        IQueryable<Supplement> supplements = context.Supplements
            .Include(s => s.Brand)
            .Include(s => s.Category);

        if (!string.IsNullOrWhiteSpace(query))
        {
            supplements = supplements.Where(s =>
                s.Name.Contains(query) ||
                (s.Description != null && s.Description.Contains(query)));
        }

        supplements = sortOrder == "desc"
            ? supplements.OrderByDescending(s => s.Price)
            : supplements.OrderBy(s => s.Price);

        ViewBag.Query = query;
        ViewBag.SortOrder = sortOrder;
        return View(await supplements.ToListAsync());
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        Supplement? supplement = await context.Supplements
            .Include(s => s.Brand)
            .Include(s => s.Category)
            .SingleOrDefaultAsync(s => s.SupplementId == id);

        return supplement is null ? NotFound() : View(supplement);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Buy(Guid id, int quantity = 1)
    {
        Supplement? supplement = await context.Supplements
            .Include(s => s.Brand)
            .Include(s => s.Category)
            .SingleOrDefaultAsync(s => s.SupplementId == id);
        if (supplement is null)
        {
            return NotFound();
        }

        return RedirectToAction("Supplement", "Checkout", new { supplementId = id, quantity });
    }
}