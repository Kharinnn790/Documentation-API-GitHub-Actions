
namespace Domain.Models;

public class Goal
{
    public int GoalId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? TargetDate { get; set; }

    public int? Priority { get; set; }

    public string? Status { get; set; }

    public int? Progress { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? User { get; set; }
}