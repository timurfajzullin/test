using System.Text.Json.Serialization;

namespace Models;

public class Author
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    
    public List<Book> Books { get; set; } = [];
}