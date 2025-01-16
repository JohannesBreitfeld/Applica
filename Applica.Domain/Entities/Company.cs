
namespace Applica.Domain.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; } = null!;

        public string? Url { get; set; }

        public List<Activity>? Activities { get; set; }

        public List<Comment>? Comments { get; set; }

        public List<ContactPerson>? ContactPeople { get; set; }
    }
}
