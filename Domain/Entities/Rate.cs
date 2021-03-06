using Domain.Commons;

namespace Domain.Entities
{
    public class Rate : AuditEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}