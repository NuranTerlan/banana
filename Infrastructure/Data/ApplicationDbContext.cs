using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commons.Interfaces;
using Domain.Commons;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<AuthorBookmark> AuthorBookmarks { get; set; }
        public DbSet<AuthorBadge> AuthorBadges { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entityEntry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Entity.CreationTime = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.LastModificationTime = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
