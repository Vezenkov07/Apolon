using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apolon.Data.Models;

public class PaymentTransaction
{
    [Key]
    public Guid PaymentId { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public decimal Amount { get; set; }

    [Required, MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Required, MaxLength(30)]
    public string Status { get; set; } = "Paid";

    [Required, MaxLength(30)]
    public string PaymentMethod { get; set; } = "Card";

    [Required, MaxLength(4)]
    public string LastFourDigits { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
