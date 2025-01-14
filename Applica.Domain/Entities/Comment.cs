
namespace Applica.Domain.Entities
{
    public class Comment : EntityBase
    {
        public string Label { get; set; } = null!;

        public string? Content { get; set; }
    }
}
