namespace BookTracker.Persistence.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public IEnumerable<BookAuthor>? BookAuthors { get; set; }
}
