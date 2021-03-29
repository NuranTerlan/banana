using Domain.Commons;

namespace Domain.Entities
{
    public class Author : AuditEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
    }
}