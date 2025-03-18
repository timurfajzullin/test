using BooksAndAuthors.Common.Mappings;
using BooksAndAuthors.Database;
using BooksAndAuthors.Database.Models;
using Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksAndAuthors.Controllers.Services;

public class AuthorService : IAuthorService
{
    private readonly IBookContext _authorContext;

    public AuthorService(IBookContext authorContext)
    {
        _authorContext = authorContext;
    }

    public async Task<List<AuthorDto>> GetAuthors()
    {
        return await _authorContext.Authors
            .Include(a => a.Books)
            .Select(x => Mapper.ToAuthorDto(x))
            .ToListAsync();
    }

    public async Task<AuthorDto?> GetAuthorById(Guid id)
    {
        return await _authorContext.Authors
            .Where(x => x.Id == id)
            .Include(a => a.Books)
            .Select(x => Mapper.ToAuthorDto(x))
            .FirstOrDefaultAsync();
    }

    public async Task AddAuthor(CreateAuthorDto author)
    {
        await _authorContext.Authors
            .AddAsync(Mapper.FromAuthorDto(author));
        await _authorContext.SaveChangesAsync();
    }

    public async Task UpdateAuthor(Guid id, [FromBody] CreateAuthorDto author)
    {
        var authorToUpdate = _authorContext.Authors
            .FirstOrDefault(x => x.Id == id);
        if (authorToUpdate != null)
        { 
            authorToUpdate.Name = author.Name;
            _authorContext.Authors.Update(authorToUpdate);
            await _authorContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAuthor(Guid id)
    {
        _authorContext.Authors.Remove(await _authorContext.Authors.Where(x => x.Id == id).FirstOrDefaultAsync());
        await _authorContext.SaveChangesAsync();
    }
}