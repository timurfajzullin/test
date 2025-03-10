using BooksAndAuthors.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BooksAndAuthors.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions) : base(dbContextOptions) 
        {
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BooksConfig());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}