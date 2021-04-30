using Audiobooks.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Audiobooks.Data
{
    public class BooksContext : IdentityDbContext<IdentityUser>
    {
        public BooksContext() : base("DefaultConnection") { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Archive> Archives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Genre)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.GenreId);

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Reader)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.ReaderId);
        }
    }
}
