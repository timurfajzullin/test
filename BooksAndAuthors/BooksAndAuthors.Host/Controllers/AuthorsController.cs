using BooksAndAuthors.Controllers.Services;
using Contracts.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksAndAuthors.Controllers
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
        
        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorDto authorDto)
        {
            await _authorService.AddAuthor(authorDto);
            return Ok(new { Message = "Успешно добавлено", Author = authorDto});
        }
        
        [Authorize]
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _authorService.DeleteAuthor(id);
            return Ok(new { Message = "Успешно удалено", AuthorId = id });
        }
        
        [Authorize]
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] CreateAuthorDto authorDto)
        {
            await _authorService.UpdateAuthor(id, authorDto);
            return Ok(new { Message = "Успешно обновлено", Author = authorDto });
        }
    }
}
