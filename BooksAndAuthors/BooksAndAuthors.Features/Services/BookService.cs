using BooksAndAuthors.Database;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BooksAndAuthors.Controllers.Services;

public class BookService
{
    private readonly IBookContext _bookContext;

    public BookService(IBookContext bookContext)
    {
        _bookContext = bookContext;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _bookContext.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await _bookContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddBookAsync(Book book)
    {
        await _bookContext.Books.AddAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        _bookContext.Books.Update(book);
    }
    
    public async Task DeleteBookAsync(Guid id)
    {
        _bookContext.Books.Remove(await _bookContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync());
    }
}