using AutoMapper;
using BooksAndAuthors.Controllers.Services;
using Contracts.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndAuthors.Controllers;

[Route("/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _booksService;
    
    public BooksController(IBookService booksService)
    {
        _booksService = booksService;
    }
    
    [HttpGet("TakeAll")]
    public async Task<IActionResult> GetAllBooks()
    {
        var result = await _booksService.GetBooks();
        return Ok(result);
    }
    
    [HttpGet("{id}/TakeById")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var result = await _booksService.GetBookById(id);
        return Ok(result);
    }
    [Authorize]
    [HttpPost("{authorId}/Create")]
    public async Task<IActionResult> AddBook(Guid authorId, CreateBookDto bookDto)      
    {
        await _booksService.AddBook(bookDto, authorId);
        return Ok(new { Message = "Успешно добавлено", Book = bookDto});
    }
    [Authorize]
    [HttpPut("{id}/Update")]
    public async Task<IActionResult> UpdateBook(Guid id , [FromBody] CreateBookDto bookDto)
    {
        await _booksService.UpdateBook(id, bookDto);
        return Ok(new { Message = "Успешно обновлено", Book = bookDto});
    }
    [Authorize]
    [HttpDelete("{id}/Delete")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _booksService.DeleteBook(id);
        return Ok("Успешно удалено");
    }
}