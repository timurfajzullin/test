namespace BooksAndAuthors.Database.Models;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public bool ISBN { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid AuthorId { get; set; } = Guid.Empty;
    public Author Author { get; set; }
}