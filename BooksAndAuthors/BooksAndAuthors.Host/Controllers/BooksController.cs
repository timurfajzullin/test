using AutoMapper;
using BooksAndAuthors.Controllers.Services;
using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BooksAndAuthors.Controllers;

[Route("/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookService _booksService;
    private readonly IMapper _mapper;
    
    public BooksController(BookService booksService, IMapper mapper)
    {
        _booksService = booksService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _booksService.GetBooks();
        var result = _mapper.Map<List<BookDto>>(books);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var book = await _booksService.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();
        
        var result = _mapper.Map<BookDto>(book);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _booksService.AddBookAsync(book);
        return Ok("Успешно добавлено");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
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