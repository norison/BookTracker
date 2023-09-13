namespace BookTracker.Persistence.Entities;

public class BookAuthor
{
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public long BookId { get; set; }
    public Book? Book { get; set; }
}
