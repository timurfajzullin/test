using BooksAndAuthors.Common.Mappings;
using BooksAndAuthors.Database;
using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Controllers.Services;

public class BookService : IBookService
{
    private readonly IBookContext _bookContext;

    public BookService(IBookContext bookContext)
    {
        _bookContext = bookContext;
    }

    public async Task<List<BookDto>> GetBooks()
    {
        return await _bookContext.Books
            .Include(x => x.Author)
            .Select(x => Mapper.ToBookDto(x))
            .ToListAsync();
    }

    public async Task<BookDto?> GetBookById(Guid id)
    {
        return await _bookContext.Books
            .Where(x => x.Id == id)
            .Include(x => x.Author)
            .Select(x => Mapper.ToBookDto(x))
            .FirstOrDefaultAsync();
    }

    public async Task AddBook(CreateBookDto book, Guid authorId)
    {
        await _bookContext.Books.AddAsync(Mapper.FromBookDto(book, authorId));
        await _bookContext.SaveChangesAsync();
    }

    public async Task UpdateBook(Guid id, [FromBody] CreateBookDto book)
    {
        var bookToUpdate = _bookContext.Books
            .FirstOrDefault(x => x.Id == id);
        if (bookToUpdate != null)
        {
            bookToUpdate.Title = book.Title;
            bookToUpdate.Description = book.Description;
            bookToUpdate.ISBN = book.ISBN;
            _bookContext.Books.Update(bookToUpdate);
            await _bookContext.SaveChangesAsync();
        }
    }

    public async Task DeleteBook(Guid id)
    {
        _bookContext.Books.Remove(await _bookContext.Books.FindAsync(id));
        await _bookContext.SaveChangesAsync();
    }
}