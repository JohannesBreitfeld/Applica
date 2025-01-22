
namespace Applica.Domain.Entities;

public class Activity : EntityBase
{
    public string? Category { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly? FollowUpDate { get; set; }
}
