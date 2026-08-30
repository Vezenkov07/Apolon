using System.ComponentModel.DataAnnotations;
using Apolon.Common;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class SupplementBrand
{
    [Comment("Unique identifier for the supplement brand")]
    [Key]
    public Guid BrandId { get; set; } = Guid.NewGuid();

    [Comment("Name of the supplement brand")]
    [Required(ErrorMessage = ModelConstants.SupplementBrand.BrandNameRequiredErrorMessage)]
    [MinLength(ModelConstants.SupplementBrand.BrandNameMinLength, ErrorMessage = ModelConstants.SupplementBrand.BrandNameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.SupplementBrand.BrandNameMaxLength, ErrorMessage = ModelConstants.SupplementBrand.BrandNameMaxLengthErrorMessage)]
    public string BrandName { get; set; } = string.Empty;

    [Comment("Contact email of the brand")]
    [Required(ErrorMessage = ModelConstants.SupplementBrand.EmailRequiredErrorMessage)]
    [EmailAddress(ErrorMessage = ModelConstants.SupplementBrand.EmailAllowedErrorMessage)]
    public string Email { get; set; } = string.Empty;

    [Comment("Contact phone number of the brand")]
    [Required(ErrorMessage = ModelConstants.SupplementBrand.PhoneNumberRequiredErrorMessage)]
    [RegularExpression(ModelConstants.SupplementBrand.PhoneNumberRegex, ErrorMessage = ModelConstants.SupplementBrand.PhoneNumberAllowedErrorMessage)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Comment("Description of the brand and its products")]
    [MaxLength(ModelConstants.SupplementBrand.DescriptionMaxLength, ErrorMessage = ModelConstants.SupplementBrand.DescriptionMaxLengthErrorMessage)]
    public string? Description { get; set; }
}