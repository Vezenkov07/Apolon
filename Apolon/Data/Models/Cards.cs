using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apolon.Common;
using Apolon.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class Card
{
    [Comment("Unique identifier for the card")]
    [Key]
    public Guid CardId { get; set; } = Guid.NewGuid();

    [Comment("Type of membership/subscription card")]
    [Required(ErrorMessage = ModelConstants.Card.CardTypeRequiredErrorMessage)]
    [EnumDataType(typeof(CardTypes), ErrorMessage = ModelConstants.Card.AllowedCardTypesErrorMessage)]
    public CardTypes CardType { get; set; }

    [Comment("Foreign key referencing the associated user")]
    [Required(ErrorMessage = ModelConstants.Card.UserIdRequiredErrorMessage)]
    public Guid UserId { get; set; }

    [Comment("Navigation property to the associated user")]
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    [Comment("Price of the card")]
    [Required(ErrorMessage = ModelConstants.Card.PriceRequiredErrorMessage)]
    [Range(typeof(decimal), ModelConstants.Card.PriceRangeMinimum, ModelConstants.Card.PriceRangeMaximum, ErrorMessage = ModelConstants.Card.PriceRangeErrorMessage)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}