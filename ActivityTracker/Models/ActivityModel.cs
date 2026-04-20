using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Models;

public class ActivityModel
{
    [Key]
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Date { get; set; }
}