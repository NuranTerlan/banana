using Domain.Commons;

namespace Domain.Entities
{
    public class Category : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}