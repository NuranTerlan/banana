namespace Domain.Entities
{
    public class AuthorBookmark
    {
        public string AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}