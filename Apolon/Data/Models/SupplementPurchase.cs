using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class SupplementPurchase
{
    [Key]
    public Guid PurchaseId { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    public Guid SupplementId { get; set; }

    [ForeignKey(nameof(SupplementId))]
    public Supplement Supplement { get; set; } = null!;

    [Range(1, 99)]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
}
