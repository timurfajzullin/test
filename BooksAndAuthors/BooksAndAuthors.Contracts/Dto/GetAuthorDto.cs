namespace Contracts.Dto;

public class GetAuthorDto
{
    public string Name { get; set; } = string.Empty;
    public List<GetBookDto> Books { get; set; } = new();
}