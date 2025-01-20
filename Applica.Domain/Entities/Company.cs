
namespace Applica.Domain.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; } = null!;

        public string? Url { get; set; }

        public ICollection<Activity>? Activities { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<ContactPerson>? ContactPeople { get; set; }
    }
}
