using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Apolon.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }
    
}