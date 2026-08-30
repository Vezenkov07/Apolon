using System.Security.Claims;
using Apolon.Data.Data;
using Apolon.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Apolon.Controllers;

public class AccountController : Controller
{
private readonly ApplicationDbContext context;

public AccountController(ApplicationDbContext _context)
{
    this.context = _context;
}
    [HttpGet]
    public IActionResult Login() => View();

    [HttpGet]
    public IActionResult Register()=> View();

    [HttpPost]
    public async Task<IActionResult> Register(string firstName,string lastName,string email,string password,string confirmPassword)
    {
        if (confirmPassword != password)
        {
            ModelState.AddModelError("","Passwords do not match!");
        }

        if (context.Users.Any(u => u.Email == email))
        {
            ModelState.AddModelError("", "There is a user with the same email address!");
        }
        
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        User user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordHash = hashedPassword,
        };
        
        context.Users.Add(user);
        await context.SaveChangesAsync();
        
        return RedirectToAction("Login");
    }
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password,bool rememberMe=false)
    {
        var user = context.Users.SingleOrDefault(u => u.Email == email);
        
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
// This tells ASP.NET Core to keep the cookie alive after the browser closes
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = rememberMe 
        };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    public IActionResult ExternalLogin(string provider)
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("ExternalLoginCallback") };
        return Challenge(properties, provider);
    }

    [HttpGet]
    public async Task<IActionResult> ExternalLoginCallback()
    {
        // 1. Read the temporary external cookie
        var result = await HttpContext.AuthenticateAsync("ExternalCookie");
        if (!result.Succeeded) return RedirectToAction("Login");

        var email = result.Principal.FindFirstValue(ClaimTypes.Email);
        var name = result.Principal.FindFirstValue(ClaimTypes.Name) ?? "";

        // 2. Check if this user exists in your PostgreSQL DB
        var user = context.Users.SingleOrDefault(u => u.Email == email);
        if (user == null)
        {
            // Auto-register them if they don't exist
            user = new User
            {
                Email = email,
                FirstName = name.Split(' ').FirstOrDefault() ?? "New",
                LastName = name.Split(' ').Skip(1).FirstOrDefault() ?? "User",
                PasswordHash = "" // No password needed for social logins
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        // 3. Log them in to your main system
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        // 4. Delete the temporary external cookie
        await HttpContext.SignOutAsync("ExternalCookie");

        return RedirectToAction("Index", "Home");
    }
}