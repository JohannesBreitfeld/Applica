
namespace Applica.Domain.Entities;

public class Activity : EntityBase
{
    public ActivityCategory Category { get; set; } = null!;

    public List<Comment>? Comments { get; set; }

    public List<ContactPerson>? ContactPeople { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly? FollowUpDate { get; set; }
}
