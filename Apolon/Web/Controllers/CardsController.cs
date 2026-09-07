using Apolon.Data.Models.Enums;
using Apolon.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Apolon.Controllers;

public class CardsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(GetOffers());
    }

    [HttpGet]
    public IActionResult Buy(CardTypes cardType)
    {
        if (!TryGetPrice(cardType, out _))
        {
            return BadRequest("Invalid membership.");
        }

        return RedirectToAction("Membership", "Checkout", new { cardType });
    }

    private static IReadOnlyCollection<CardOfferViewModel> GetOffers() =>
    [
        new() { CardType = CardTypes.Standard, Price = 39.99m, Description = "Gym access during staffed hours." },
        new() { CardType = CardTypes.Silver, Price = 59.99m, Description = "Gym access plus one trainer consultation." },
        new() { CardType = CardTypes.Gold, Price = 89.99m, Description = "Gym access plus four trainer consultations." },
        new() { CardType = CardTypes.Premium, Price = 129.99m, Description = "Unlimited access and priority trainer booking." }
    ];

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

    public static decimal GetPrice(CardTypes type)
    {
        if (!TryGetPrice(type, out decimal price))
        {
            throw new ArgumentOutOfRangeException(nameof(type));
        }

        return price;
    }
}
