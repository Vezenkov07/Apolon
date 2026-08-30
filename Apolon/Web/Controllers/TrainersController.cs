using Apolon.Data.Data;
using Apolon.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apolon.Controllers;

public class TrainersController : Controller
{
    private ApplicationDbContext context;

    public TrainersController(ApplicationDbContext _context)
    {
        this.context = _context;
    }
    [HttpGet]
    // GET
    public IActionResult Index()
    {
        List<Trainer> trainers = context.Trainers.ToList();
        return View(trainers);
    }
}