namespace Domain.Entities
{
    public class AuthorBadge
    {
        public string AuthorId { get; set; }
        public Author Author { get; set; }

        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}