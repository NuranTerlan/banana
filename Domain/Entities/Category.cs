using System.Collections;
using System.Collections.Generic;
using Domain.Commons;

namespace Domain.Entities
{
    public class Category : AuditEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}