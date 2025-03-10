using BooksAndAuthors.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Npgsql.NameTranslation;

namespace BooksAndAuthors.Controllers;

[Route("/authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _authorService;

    public AuthorsController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _authorService.GetAuthorsAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        var author = await _authorService.GetAuthorByIdAsync(id);
        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor(Author author)
    {
        await _authorService.AddAuthorAsync(author);
        return Ok("Успешно добавлено");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        await _authorService.DeleteAuthorAsync(id);
        return Ok("Успешно удалено");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(Author author)
    {
        await _authorService.UpdateAuthorAsync(author);
        return Ok("Успешно обновлено");
    }
}