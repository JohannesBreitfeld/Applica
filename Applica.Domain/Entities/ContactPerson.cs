
namespace Applica.Domain.Entities
{
    public class ContactPerson : EntityBase
    {
        public string Name { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
