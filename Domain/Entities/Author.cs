using System.Collections;
using System.Collections.Generic;
using Domain.Commons;

namespace Domain.Entities
{
    public class Author : AuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string RealJob { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<AuthorBookmark> AuthorBookmarks { get; set; }
        public virtual ICollection<AuthorBadge> AuthorBadges { get; set; }
    }
}