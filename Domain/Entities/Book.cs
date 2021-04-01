using Domain.Commons;

namespace Domain.Entities
{
    public class Book : AuditEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}