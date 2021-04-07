using System;
using System.Collections.Generic;
using Domain.Commons;

namespace Domain.Entities
{
    public class Book : AuditEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool IsPublished { get; set; }
        public short PageCount { get; set; }
        public int ReadCount { get; set; }

        public int RateId { get; set; }
        public virtual Rate Rate { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public virtual ICollection<AuthorBookmark> AuthorBookmarks { get; set; }
    }
}