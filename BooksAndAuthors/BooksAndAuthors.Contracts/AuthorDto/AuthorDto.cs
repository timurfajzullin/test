namespace Contracts.Dto;

public class AuthorDto
{
    public string Name { get; set; } = string.Empty;
    public List<BookDto> Books { get; set; } = new();
}