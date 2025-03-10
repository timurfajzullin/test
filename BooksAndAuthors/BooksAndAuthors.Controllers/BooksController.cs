using BooksAndAuthors.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BooksAndAuthors.Controllers;

[Route("/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookService _booksService;
    
    public BooksController(BookService booksService)
    {
        _booksService = booksService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var result = await _booksService.GetBooks();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var result = await _booksService.GetBookByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        await _booksService.AddBookAsync(book);
        return Ok("Успешно добавлено");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        await _booksService.UpdateBookAsync(book);
        return Ok("Успешно обновлено");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _booksService.DeleteBookAsync(id);
        return Ok("Успешно удалено");
    }
}