using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apolon.Common;
using Microsoft.EntityFrameworkCore;

namespace Apolon.Data.Models;

public class Workout
{
    [Comment("Unique identifier for the workout session")]
    [Key]
    public Guid WorkoutId { get; set; } = Guid.NewGuid();

    [Comment("Foreign key referencing the workout split")]
    [Required(ErrorMessage = ModelConstants.Workout.SplitIdRequiredErrorMessage)]
    public Guid SplitId { get; set; }

    [Comment("Navigation property to the assigned split")]
    [ForeignKey(nameof(SplitId))]
    public Split Split { get; set; } = null!;

    [Comment("Start date and time of the workout session")]
    [Required(ErrorMessage = ModelConstants.Workout.StartTimeRequiredErrorMessage)]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [Comment("End date and time of the workout session")]
    [Required(ErrorMessage = ModelConstants.Workout.EndTimeRequiredErrorMessage)]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }

    [Comment("Optional foreign key referencing an assigned trainer")]
    public Guid? TrainerId { get; set; }

    [Comment("Navigation property to the assigned trainer")]
    [ForeignKey(nameof(TrainerId))]
    public Trainer? Trainer { get; set; }
}