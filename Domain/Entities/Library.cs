using System.Collections.Generic;
using Domain.Commons;

namespace Domain.Entities
{
    public class Library : AuditEntity
    {
        public Library()
        {
            Books = new List<Book>();
        }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}