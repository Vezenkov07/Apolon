using System.ComponentModel.DataAnnotations;
using Apolon.Common;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class Trainer
{
    [Comment("Unique identifier")]
    [Key]
    public Guid TrainerId { get; set; }= Guid.NewGuid();  
    
    [Comment("First name of the trainer")]
    [Required(ErrorMessage = ModelConstants.Trainer.FirstNameRequiredErrorMessage)]
    [MinLength(ModelConstants.Trainer.FirstNameMinLength,ErrorMessage = ModelConstants.Trainer.FirstNameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.Trainer.FirstNameMaxLength, ErrorMessage = ModelConstants.Trainer.FirstNameMaxLengthErrorMessage)]
    public string FirstName { get; set; } = string.Empty;
    
    [Comment("Last name of the trainer")]
    [Required(ErrorMessage = ModelConstants.Trainer.LastNameRequiredErrorMessage)]
    [MinLength(ModelConstants.Trainer.LastNameMinLength,ErrorMessage = ModelConstants.Trainer.LastNameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.Trainer.LastNameMaxLength,ErrorMessage = ModelConstants.Trainer.LastNameMaxLengthErrorMessage)]
    public string LastName { get; set; } = string.Empty;
    
    [Comment("Trainer sex")]
    [Required(ErrorMessage = ModelConstants.Trainer.GenderRequiredErrorMessage)]
    [AllowedValues(ModelConstants.Trainer.AllowedGenderMale, ModelConstants.Trainer.AllowedGenderFemale,ErrorMessage = ModelConstants.Trainer.GenderRequiredErrorMessage)]
    public char Gender { get; set; }
    
    [Comment("Email of the trainer")]
    [Required(ErrorMessage = ModelConstants.Trainer.EmailRequiredErrorMessage)]
    [EmailAddress(ErrorMessage = ModelConstants.Trainer.EmailAllowedErrorMessage)]
    public string Email { get; set; } = string.Empty;
    
    [Comment("Phone number of the trainer")]
    [Required(ErrorMessage = ModelConstants.Trainer.PhoneNumberRequiredErrorMessage)]
    [RegularExpression(ModelConstants.Trainer.PhoneNumberRegex,ErrorMessage = ModelConstants.Trainer.PhoneNumberAllowedErrorMessage)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Comment("The Image Of The Trainer")]
    [Required(ErrorMessage = ModelConstants.Trainer.ImageRequiredErrorMessage)]
    [MinLength(ModelConstants.Trainer.ImageUrlMinLength)]
    [MaxLength(ModelConstants.Trainer.ImageUrlMaxLength)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [Comment("Description for the trainer")]
    [MaxLength(ModelConstants.Trainer.DescriptionMaxLength,ErrorMessage = ModelConstants.Trainer.DescriptionMaxLengthErrorMessage)]
    public string? Description { get; set; }
}