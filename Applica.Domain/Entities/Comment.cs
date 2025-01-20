
namespace Applica.Domain.Entities
{
    public class Comment : EntityBase
    {
        public string Label { get; set; } = null!;

        public DateOnly Date { get; set; }

        public string? Content { get; set; }
    }
}
