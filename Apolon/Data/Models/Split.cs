using System.ComponentModel.DataAnnotations;
using Apolon.Common;
using Apolon.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class Split
{
    [Comment("Unique identifier for the workout split")]
    [Key]
    public Guid SplitId { get; set; } = Guid.NewGuid();

    [Comment("Name of the workout split (e.g., Push/Pull/Legs, Upper/Lower)")]
    [Required(ErrorMessage = ModelConstants.Split.SplitNameRequiredErrorMessage)]
    [MinLength(ModelConstants.Split.SplitNameMinLength, ErrorMessage = ModelConstants.Split.SplitNameMinLengthErrorMessage)]
    [MaxLength(ModelConstants.Split.SplitNameMaxLength, ErrorMessage = ModelConstants.Split.SplitNameMaxLengthErrorMessage)]
    public string SplitName { get; set; } = string.Empty;

    [Comment("List of targeted muscle groups included in this split")]
    [Required(ErrorMessage = ModelConstants.Split.TargetedMusclesRequiredErrorMessage)]
    public List<Muscles> TargetedMuscles { get; set; } = new();
}