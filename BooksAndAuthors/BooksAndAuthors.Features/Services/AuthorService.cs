using BooksAndAuthors.Database;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BooksAndAuthors.Controllers.Services;

public class AuthorService
{
    private IBookContext _authorContext;

    public AuthorService(IBookContext authorContext)
    {
        _authorContext = authorContext;
    }
    
    public async Task<List<Author>> GetAuthors()
    {
        return await _authorContext.Authors.Include(a => a.Books).ToListAsync();
    }

    public async Task<Author?> GetAuthorById(Guid id)
    {
        return await _authorContext.Authors.Where(x => x.Id == id).Include(a => a.Books).FirstOrDefaultAsync();
    }

    public async Task AddAuthor(Author author)
    {
        await _authorContext.Authors.AddAsync(author);
        await _authorContext.SaveChangesAsync();
    }

    public async Task UpdateAuthor(Author author)
    {
        _authorContext.Authors.Update(author);
        await _authorContext.SaveChangesAsync();
    }

    public async Task DeleteAuthor(Guid id)
    {
        _authorContext.Authors.Remove(await _authorContext.Authors.Where(x => x.Id == id).FirstOrDefaultAsync());
        await _authorContext.SaveChangesAsync();
    }
}