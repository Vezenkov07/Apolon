using System.Security.Claims;
using Apolon.Data.Data;
using Apolon.Data.Models;
using Apolon.Data.Models.Enums;
using Apolon.Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Controllers;

[Authorize]
public class CheckoutController : Controller
{
    private readonly ApplicationDbContext context;

    public CheckoutController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult Membership(CardTypes cardType)
    {
        if (!TryGetPrice(cardType, out decimal price))
        {
            return BadRequest("Invalid membership.");
        }

        return View("Index", new CheckoutViewModel
        {
            PurchaseType = "Membership",
            CardType = cardType,
            ProductName = $"{cardType} membership",
            Total = price
        });
    }

    [HttpGet]
    public async Task<IActionResult> Supplement(Guid supplementId, int quantity = 1)
    {
        Apolon.Data.Models.Supplement? supplement = await context.Supplements.FindAsync(supplementId);
        if (supplement is null || quantity is < 1 or > 99)
        {
            return NotFound();
        }

        return View("Index", new CheckoutViewModel
        {
            PurchaseType = "Supplement",
            SupplementId = supplement.SupplementId,
            Quantity = quantity,
            ProductName = $"{quantity} × {supplement.Name}",
            Total = supplement.Price * quantity
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Membership(CheckoutViewModel model)
    {
        if (!model.CardType.HasValue || !TryGetPrice(model.CardType.Value, out decimal price))
        {
            return BadRequest("Invalid membership.");
        }

        model.PurchaseType = "Membership";
        model.ProductName = $"{model.CardType.Value} membership";
        model.Total = price;

        if (!ModelState.IsValid || !IsCardValid(model.CardNumber, model.ExpiryMonth, model.ExpiryYear))
        {
            AddPaymentErrorIfNeeded();
            return View("Index", model);
        }

        if (!TryGetUserId(out Guid userId))
        {
            return Challenge();
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        context.PaymentTransactions.Add(CreatePayment(userId, model));
        context.Cards.Add(new Card
        {
            UserId = userId,
            CardType = model.CardType.Value,
            Price = price
        });
        await context.SaveChangesAsync();
        await transaction.CommitAsync();

        TempData["SuccessMessage"] = $"{model.ProductName} purchased successfully.";
        return RedirectToAction("Index", "Account");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Supplement(CheckoutViewModel model)
    {
        if (!model.SupplementId.HasValue)
        {
            return BadRequest("Invalid supplement.");
        }

        Apolon.Data.Models.Supplement? supplement = await context.Supplements.FindAsync(model.SupplementId.Value);
        if (supplement is null || model.Quantity is < 1 or > 99)
        {
            return NotFound();
        }

        model.PurchaseType = "Supplement";
        model.ProductName = $"{model.Quantity} × {supplement.Name}";
        model.Total = supplement.Price * model.Quantity;

        if (!ModelState.IsValid || !IsCardValid(model.CardNumber, model.ExpiryMonth, model.ExpiryYear))
        {
            AddPaymentErrorIfNeeded();
            return View("Index", model);
        }

        if (!TryGetUserId(out Guid userId))
        {
            return Challenge();
        }

        await using var transaction = await context.Database.BeginTransactionAsync();
        context.PaymentTransactions.Add(CreatePayment(userId, model));
        context.SupplementPurchases.Add(new SupplementPurchase
        {
            UserId = userId,
            SupplementId = supplement.SupplementId,
            Quantity = model.Quantity,
            UnitPrice = supplement.Price
        });
        await context.SaveChangesAsync();
        await transaction.CommitAsync();

        TempData["SuccessMessage"] = $"{model.ProductName} purchased successfully.";
        return RedirectToAction("Index", "Account");
    }

    private PaymentTransaction CreatePayment(Guid userId, CheckoutViewModel model) =>
        new()
        {
            UserId = userId,
            Amount = model.Total,
            Description = model.ProductName,
            LastFourDigits = new string(model.CardNumber.Where(char.IsDigit).TakeLast(4).ToArray())
        };

    private void AddPaymentErrorIfNeeded()
    {
        if (!ModelState.Values.SelectMany(value => value.Errors).Any(error =>
                error.ErrorMessage?.Contains("card", StringComparison.OrdinalIgnoreCase) == true))
        {
            ModelState.AddModelError(string.Empty, "The payment details could not be verified.");
        }
    }

    private static bool IsCardValid(string cardNumber, int month, int year)
    {
        string digits = new(cardNumber.Where(char.IsDigit).ToArray());
        if (digits.Length is < 13 or > 19 ||
            month is < 1 or > 12 ||
            year is < 1 or > 9999 ||
            !LuhnValid(digits))
        {
            return false;
        }

        DateTime expiry = new DateTime(year, month, 1).AddMonths(1);
        return expiry > DateTime.UtcNow;
    }

    private static bool LuhnValid(string digits)
    {
        int sum = 0;
        bool doubleDigit = false;
        for (int index = digits.Length - 1; index >= 0; index--)
        {
            int digit = digits[index] - '0';
            if (doubleDigit && (digit *= 2) > 9)
            {
                digit -= 9;
            }
            sum += digit;
            doubleDigit = !doubleDigit;
        }

        return sum % 10 == 0;
    }

    private static bool TryGetPrice(CardTypes type, out decimal price)
    {
        price = type switch
        {
            CardTypes.Standard => 39.99m,
            CardTypes.Silver => 59.99m,
            CardTypes.Gold => 89.99m,
            CardTypes.Premium => 129.99m,
            _ => 0m
        };
        return price > 0;
    }

    private bool TryGetUserId(out Guid userId) =>
        Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId);
}
