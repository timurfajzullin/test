using BooksAndAuthors.Database.Repositories;
using Models;

namespace BooksAndAuthors.Controllers.Services;

public class BookService
{
    private BooksRepository booksRepository;

    public BookService(BooksRepository booksRepository)
    {
        this.booksRepository = booksRepository;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await booksRepository.GetBooksAsync();
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await booksRepository.GetBookByIdAsync(id);
    }

    public async Task AddBookAsync(Book book)
    {
        await booksRepository.AddBookAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        await booksRepository.UpdateBookAsync(book);
    }

    public async Task DeleteBookAsync(Guid id)
    {
        await booksRepository.DeleteBookAsync(id);
    }
}