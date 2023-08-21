namespace BookTracker.Persistence.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public IEnumerable<Book>? Books { get; set; }
}
