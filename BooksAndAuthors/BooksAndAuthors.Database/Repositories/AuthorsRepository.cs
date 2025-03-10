using Microsoft.EntityFrameworkCore;
using Models;

namespace BooksAndAuthors.Database.Repositories;

public class AuthorsRepository
{
    private readonly DBContext _dbContext;
    
    public AuthorsRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _dbContext.Authors
            .Include(author => author.Books)
            .ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        return await _dbContext.Authors
            .AsNoTracking()
            .Include(author => author.Books)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAuthorAsync(Author author)
    {
        await _dbContext.Authors.AddAsync(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        _dbContext.Authors.Update(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        await _dbContext.Authors.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}