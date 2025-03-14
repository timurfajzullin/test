using AutoMapper;
using BooksAndAuthors.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Threading.Tasks;
using Contracts.Dto;

namespace BooksAndAuthors.Features
{
    [Route("/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(AuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAuthors();
            var authorDtos = _mapper.Map<IEnumerable<GetAuthorDto>>(authors);
            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = _mapper.Map<GetAuthorDto>(author);
            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] PostAuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest();
            }
            var author = _mapper.Map<Author>(authorDto);
            await _authorService.AddAuthor(author);
            return Ok(new { Message = "Успешно добавлено", Author = _mapper.Map<GetAuthorDto>(author) });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            await _authorService.DeleteAuthor(id);
            return Ok(new { Message = "Успешно удалено", AuthorId = id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] PostAuthorDto authorDto)
        {
            
            var author = _mapper.Map<Author>(authorDto);
            await _authorService.UpdateAuthor(author);
            return Ok(new { Message = "Успешно обновлено", Author = _mapper.Map<GetAuthorDto>(author) });
        }
    }
}
