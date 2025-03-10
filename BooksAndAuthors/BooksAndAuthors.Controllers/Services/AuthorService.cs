using BooksAndAuthors.Database.Repositories;
using Models;

namespace BooksAndAuthors.Controllers.Services;

public class AuthorService
{
    private AuthorsRepository _authorsRepository;

    public AuthorService(AuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _authorsRepository.GetAuthorsAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        return await _authorsRepository.GetAuthorByIdAsync(id);
    }

    public async Task AddAuthorAsync(Author author)
    {
        await _authorsRepository.AddAuthorAsync(author);
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        await _authorsRepository.UpdateAuthorAsync(author);
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        await _authorsRepository.DeleteAuthorAsync(id);
    }
}