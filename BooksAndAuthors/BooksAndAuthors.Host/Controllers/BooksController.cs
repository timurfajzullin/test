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
        var result = _mapper.Map<List<GetBookDto>>(books);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var book = await _booksService.GetBookByIdAsync(id);
        if (book == null)
            return NotFound();
        
        var result = _mapper.Map<GetBookDto>(book);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(PostBookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _booksService.AddBookAsync(book);
        return Ok("Успешно добавлено");
    }

    [HttpPut("{bookId}")]
    public async Task<IActionResult> UpdateBook(Guid boodId , [FromBody] PostBookDto bookDto)
    {
        var bookToUpdate = await _booksService.GetBookByIdAsync(boodId);
        _mapper.Map(bookDto, bookToUpdate);
        if (bookToUpdate != null) await _booksService.UpdateBookAsync(bookToUpdate);
        var updatedBookDto = _mapper.Map<GetBookDto>(bookToUpdate);
        return Ok(new { Message = "Успешно обновлено", Book = updatedBookDto});
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _booksService.DeleteBookAsync(id);
        return Ok("Успешно удалено");
    }
}