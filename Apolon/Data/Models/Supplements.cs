using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apolon.Common;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class Supplement
{
    [Comment("Unique identifier for the supplement")]
    [Key]
    public Guid SupplementId { get; set; } = Guid.NewGuid();

    [Comment("Name of the supplement")]
    [Required(ErrorMessage = ModelConstants.Supplement.NameRequiredErrorMessage)]
    [MinLength(ModelConstants.Supplement.NameMinLength, ErrorMessage = ModelConstants.Supplement.NameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.Supplement.NameMaxLength, ErrorMessage = ModelConstants.Supplement.NameMaxLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    [Comment("Price of the supplement")]
    [Required(ErrorMessage = ModelConstants.Supplement.PriceRequiredErrorMessage)]
    [Range(typeof(decimal), ModelConstants.Supplement.PriceRangeMinimum, ModelConstants.Supplement.PriceRangeMaximum, ErrorMessage = ModelConstants.Supplement.PriceRangeErrorMessage)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Comment("Foreign key referencing the supplement brand")]
    [Required(ErrorMessage = ModelConstants.Supplement.BrandIdRequiredErrorMessage)]
    public Guid BrandId { get; set; }

    [Comment("Navigation property to the associated brand")]
    [ForeignKey(nameof(BrandId))]
    public SupplementBrand Brand { get; set; } = null!;

    [Comment("Foreign key referencing the supplement category")]
    [Required(ErrorMessage = ModelConstants.Supplement.CategoryIdRequiredErrorMessage)]
    public Guid CategoryId { get; set; }

    [Comment("Navigation property to the associated category")]
    [ForeignKey(nameof(CategoryId))]
    public SupplementCategory Category { get; set; } = null!;

    [Comment("Description detailing the supplement's ingredients and usage")]
    [MaxLength(ModelConstants.Supplement.DescriptionMaxLength, ErrorMessage = ModelConstants.Supplement.DescriptionMaxLengthErrorMessage)]
    public string? Description { get; set; }
}