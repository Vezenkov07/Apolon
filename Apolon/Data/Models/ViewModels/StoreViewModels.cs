using System.ComponentModel.DataAnnotations;
using Apolon.Data.Models.Enums;

namespace Apolon.Data.Models.ViewModels;

public class CardOfferViewModel
{
    public CardTypes CardType { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class BuyCardViewModel
{
    [Required]
    public CardTypes CardType { get; set; }
}
