using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apolon.Data.Models;

public class Session
{
    [Key]
    public Guid SessionId { get; set; } = Guid.NewGuid();
    
    public Guid TrainerId { get; set; }
    
    [ForeignKey(nameof(TrainerId))]
    public Trainer Trainer { get; set; }= null!;
    
    public DateOnly BookingDate { get; set; }
    
    public TimeOnly BookingTime { get; set; }
    
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }= null!;

    public string? Notes { get; set; }
}