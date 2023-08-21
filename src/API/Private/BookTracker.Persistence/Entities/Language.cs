namespace BookTracker.Persistence.Entities;

public class Language
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    public IEnumerable<Book>? Books { get; set; }
}
