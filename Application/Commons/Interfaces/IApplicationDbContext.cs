using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Badge> Badges { get; set; }
        DbSet<Rate> Rates { get; set; }
        DbSet<AuthorBookmark> AuthorBookmarks { get; set; }
        DbSet<AuthorBadge> AuthorBadges { get; set; }
        DbSet<BookCategory> BookCategories { get; set; }
        DbSet<ReaderProgress> ReaderProgresses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}