namespace BookTracker.Persistence.Entities;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Book>? Books { get; set; }
}
