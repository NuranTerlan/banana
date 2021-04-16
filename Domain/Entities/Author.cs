using System.Collections;
using System.Collections.Generic;
using Domain.Commons;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Author : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string ProfileImageUrl { get; set; }
        public string RealJob { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<AuthorBookmark> AuthorBookmarks { get; set; }
        public virtual ICollection<AuthorBadge> AuthorBadges { get; set; }
        public virtual ICollection<ReaderProgress> ReaderProgresses { get; set; }
    }
}