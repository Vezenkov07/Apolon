using System.ComponentModel.DataAnnotations;
using Apolon.Common;
using Apolon.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class SupplementCategory
{
    [Comment("Unique identifier for the supplement category")]
    [Key]
    public Guid CategoryId { get; set; } = Guid.NewGuid();

    [Comment("The category type (e.g., Protein, Creatine, Pre-Workout)")]
    [Required(ErrorMessage = ModelConstants.SupplementCategory.CategoryRequiredErrorMessage)]
    [EnumDataType(typeof(SupplementCategories), ErrorMessage = ModelConstants.SupplementCategory.AllowedCategoriesErrorMessage)]
    public SupplementCategories Category { get; set; }

    [Comment("Description detailing the category and its intended benefits")]
    [MaxLength(ModelConstants.SupplementCategory.DescriptionMaxLength, ErrorMessage = ModelConstants.SupplementCategory.DescriptionMaxLengthErrorMessage)]
    public string? CategoryDescription { get; set; }
}