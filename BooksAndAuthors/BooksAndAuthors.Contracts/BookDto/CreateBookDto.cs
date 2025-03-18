namespace Contracts.Dto;

public class CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public bool ISBN { get; set; }
    public string Description { get; set; } = string.Empty;
}