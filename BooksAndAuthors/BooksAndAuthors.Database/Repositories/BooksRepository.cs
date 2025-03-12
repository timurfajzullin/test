using Microsoft.EntityFrameworkCore;
using Models;

namespace BooksAndAuthors.Database.Repositories;

public class BooksRepository
{
    private readonly IBookContext _dbContext;

    public BooksRepository(IBookContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task AddBookAsync(Book book)
    {
        await _dbContext.Books.AddAsync(new Book
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            ISBN = book.ISBN,
            AuthorId = book.AuthorId
        });
        // await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        await _dbContext.Books.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        _dbContext.Books.Update(book);
        // await _dbContext.SaveChangesAsync();
    }
}