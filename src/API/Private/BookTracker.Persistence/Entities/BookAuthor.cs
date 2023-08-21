namespace BookTracker.Persistence.Entities;

public class BookAuthor
{
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public string BookId { get; set; } = string.Empty;
    public Book? Book { get; set; }
}
