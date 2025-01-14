
namespace Applica.Domain.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; } = null!;

        public List<Activity>? Activities { get; set; }

        public List<Comment>? Comments { get; set; }

        public List<ContactPerson>? ContactPeople { get; set; }
    }
}
