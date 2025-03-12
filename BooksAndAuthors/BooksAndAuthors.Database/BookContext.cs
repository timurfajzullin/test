using Microsoft.EntityFrameworkCore;
using Models;

namespace BooksAndAuthors.Database
{
    public class BookContext : DbContext, IBookContext
    {
        public BookContext(DbContextOptions<BookContext> dbContextOptions) : base(dbContextOptions) 
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().HasOne<Author>()
                .WithMany(a => a.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
    
    public interface IBookContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}