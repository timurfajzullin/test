using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndAuthors.Controllers.Services;

public interface IBookService
{
    public Task<List<BookDto>> GetBooks();
    
    public Task<BookDto?> GetBookById(Guid id);
    
    public Task AddBook(CreateBookDto book, Guid id);
    
    public Task UpdateBook(Guid id, [FromBody] CreateBookDto book);
    
    public Task DeleteBook(Guid id);
}