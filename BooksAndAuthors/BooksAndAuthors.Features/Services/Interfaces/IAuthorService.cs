using Contracts.Dto;

namespace BooksAndAuthors.Controllers.Services;

public interface IAuthorService
{
    public Task<List<AuthorDto>> GetAuthors();
    
    public Task<AuthorDto?> GetAuthorById(Guid id);
    
    public Task AddAuthor(CreateAuthorDto author);
    
    public Task UpdateAuthor(Guid id, CreateAuthorDto author);
    
    public Task DeleteAuthor(Guid id);
}