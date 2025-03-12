namespace Contracts.Dto;

public class BookDto
{
    public string Title { get; set; } = string.Empty;
    public bool ISBN { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
}