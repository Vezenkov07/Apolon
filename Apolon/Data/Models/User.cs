using System.ComponentModel.DataAnnotations;
using Apolon.Common;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class User
{
    [Comment("Unique identifier for the user")]
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();

    [Comment("First name of the user")]
    [Required(ErrorMessage = ModelConstants.User.FirstNameRequiredErrorMessage)]
    [MinLength(ModelConstants.User.FirstNameMinLength, ErrorMessage = ModelConstants.User.FirstNameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.User.FirstNameMaxLength, ErrorMessage = ModelConstants.User.FirstNameMaxLengthErrorMessage)]
    public string FirstName { get; set; } = string.Empty;

    [Comment("Last name of the user")]
    [Required(ErrorMessage = ModelConstants.User.LastNameRequiredErrorMessage)]
    [MinLength(ModelConstants.User.LastNameMinLength, ErrorMessage = ModelConstants.User.LastNameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.User.LastNameMaxLength, ErrorMessage = ModelConstants.User.LastNameMaxLengthErrorMessage)]
    public string LastName { get; set; } = string.Empty;

    [Comment("Date of birth of the user")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Comment("Weight of the user in kilograms")]
    [Range(ModelConstants.User.WeightMin, ModelConstants.User.WeightMax, ErrorMessage = ModelConstants.User.WeightRangeErrorMessage)]
    public double Weight { get; set; }

    [Comment("Height of the user in centimeters")]
    [Range(ModelConstants.User.HeightMin, ModelConstants.User.HeightMax, ErrorMessage = ModelConstants.User.HeightRangeErrorMessage)]
    public double Height { get; set; }
    [Comment("Hashed password of the user")]
    [Required(ErrorMessage = ModelConstants.User.PasswordRequiredErrorMessage)]
    public string PasswordHash { get; set; } = string.Empty;
     [Comment("Email of the user")]
     [EmailAddress(ErrorMessage = ModelConstants.User.EmailInvalidErrorMessage)]
     [Required(ErrorMessage = ModelConstants.User.EmailRequiredErrorMessage)]
    public string Email { get; set; }
}