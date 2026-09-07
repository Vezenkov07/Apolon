using System.ComponentModel.DataAnnotations;
using Apolon.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Apolon.Data.Models.ViewModels;

public class CheckoutViewModel
{
    [BindNever]
    public string ProductName { get; set; } = string.Empty;

    [BindNever]
    public decimal Total { get; set; }

    [BindNever]
    public string PurchaseType { get; set; } = string.Empty;

    public Guid? SupplementId { get; set; }

    public CardTypes? CardType { get; set; }

    [Range(1, 99)]
    public int Quantity { get; set; } = 1;

    [Required(ErrorMessage = "Enter the card number.")]
    [RegularExpression(@"^[0-9 ]{13,19}$", ErrorMessage = "Enter a valid card number.")]
    public string CardNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter the expiry month.")]
    [Range(1, 12, ErrorMessage = "Expiry month must be between 1 and 12.")]
    public int ExpiryMonth { get; set; }

    [Required(ErrorMessage = "Enter the expiry year.")]
    [Range(2024, 2100, ErrorMessage = "Enter a valid expiry year.")]
    public int ExpiryYear { get; set; }

    [Required(ErrorMessage = "Enter the security code.")]
    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security code must be 3 or 4 digits.")]
    public string SecurityCode { get; set; } = string.Empty;
}
