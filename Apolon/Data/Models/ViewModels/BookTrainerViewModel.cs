using System.ComponentModel.DataAnnotations;
using Apolon.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Apolon.Data.Models.ViewModels;

public class BookTrainerViewModel : IValidatableObject
{
    [BindNever]
    public Guid? SessionId { get; set; }

    public Guid TrainerId { get; set; }

    [BindNever]
    public string TrainerName { get; set; } = string.Empty;

    [BindNever]
    public string TrainerImageUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = ModelConstants.BookSession.BookingDateRequiredErrorMessage)]
    [DataType(DataType.Date)]
    public DateOnly BookingDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

    [Required(ErrorMessage = ModelConstants.BookSession.BookingTimeRequiredErrorMessage)]
    [DataType(DataType.Time)]
    public TimeOnly BookingTime { get; set; } = new(9, 0);

    [MaxLength(ModelConstants.BookSession.NoteMaxLength)]
    public string? Notes { get; set; }

    [BindNever]
    public IReadOnlyCollection<TimeOnly> AvailableTimes { get; set; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (BookingDate <= DateOnly.FromDateTime(DateTime.Today))
        {
            yield return new ValidationResult(
                ModelConstants.BookSession.BookingDatePastErrorMessage,
                [nameof(BookingDate)]);
        }

        var openingTime = new TimeOnly(ModelConstants.BookSession.OpeningHour, 0);
        var closingTime = new TimeOnly(ModelConstants.BookSession.ClosingHour, 0);
        if (BookingTime < openingTime || BookingTime >= closingTime ||
            BookingTime.Minute != 0)
        {
            yield return new ValidationResult(
                ModelConstants.BookSession.BookingTimeRequiredErrorMessage,
                [nameof(BookingTime)]);
        }
    }
}