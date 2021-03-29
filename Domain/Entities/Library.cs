using System.Collections;
using System.Collections.Generic;
using Domain.Commons;

namespace Domain.Entities
{
    public class Library : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}