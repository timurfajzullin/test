using AutoMapper;
using BooksAndAuthors.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BooksAndAuthors.Database.Models;
using Contracts.Dto;

namespace BooksAndAuthors.Features
{
    [Route("/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("TakeAll")]
        public async Task<IActionResult> GetAuthors()
        {
            var result = await _authorService.GetAuthors();
            return Ok(result);
        }

        [HttpGet("{id}/TakeById")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var result = await _authorService.GetAuthorById(id);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorDto authorDto)
        {
            await _authorService.AddAuthor(authorDto);
            return Ok(new { Message = "Успешно добавлено", Author = authorDto});
        }

        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _authorService.DeleteAuthor(id);
            return Ok(new { Message = "Успешно удалено", AuthorId = id });
        }

        [HttpPut("{id}/Update")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] CreateAuthorDto authorDto)
        {
            await _authorService.UpdateAuthor(id, authorDto);
            return Ok(new { Message = "Успешно обновлено", Author = authorDto });
        }
    }
}
