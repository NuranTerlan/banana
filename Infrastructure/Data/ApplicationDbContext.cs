using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commons.Interfaces;
using Domain.Commons;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<Author>, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<AuthorBookmark> AuthorBookmarks { get; set; }
        public DbSet<AuthorBadge> AuthorBadges { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
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

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorBadge>()
                .HasKey(ab => new {ab.AuthorId, ab.BadgeId});
            modelBuilder.Entity<AuthorBadge>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBadges)
                .HasForeignKey(ab => ab.AuthorId);
            modelBuilder.Entity<AuthorBadge>()
                .HasOne(ab => ab.Badge)
                .WithMany(b => b.AuthorBadges)
                .HasForeignKey(ab => ab.BadgeId);

            modelBuilder.Entity<AuthorBookmark>()
                .HasKey(ab => new {ab.AuthorId, ab.BookId});
            modelBuilder.Entity<AuthorBookmark>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBookmarks)
                .HasForeignKey(ab => ab.AuthorId);
            modelBuilder.Entity<AuthorBookmark>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBookmarks)
                .HasForeignKey(ab => ab.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new {bc.BookId, bc.CategoryId});
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
