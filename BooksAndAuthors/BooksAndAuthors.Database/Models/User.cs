namespace BooksAndAuthors.Database.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Login { get; set; } = string.Empty;
    public int Password { get; set; }
}