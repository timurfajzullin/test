using BooksAndAuthors.Database.Models;
using Contracts.Dto;

namespace BooksAndAuthors.Common.Mappings;

public static class Mapper
{
    public static BookDto ToBookDto(Book book)
    {
        return new BookDto
        {
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            AuthorName = book.Author.Name,
        };
    }

    public static Book FromBookDto(CreateBookDto book, Guid authorId)
    {
        return new Book
        {
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            AuthorId = authorId,
        };
    }

    public static AuthorDto ToAuthorDto(Author author)
    {
        return new AuthorDto
        {
            Name = author.Name,
            Books = author.Books.Select(x => ToBookDto(x)).ToList()
        };
    }

    public static Author FromAuthorDto(CreateAuthorDto authorDto)
    {
        return new Author
        {
            Name = authorDto.Name,
        };
    }
        
}