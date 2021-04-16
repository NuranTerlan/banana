namespace Domain.Entities
{
    public class ReaderProgress
    {
        public bool IsCompleted { get; set; }
        public int CountToComplete { get; set; }
        public int PagesPerDay { get; set; }
        public int AveragePerformance { get; set; }
        public int LastDayPagesCount { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public string AuthorId { get; set; }
        public Author Author { get; set; }
    }
}