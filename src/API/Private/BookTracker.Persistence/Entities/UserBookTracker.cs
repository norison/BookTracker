namespace BookTracker.Persistence.Entities;

public class UserBookTracker
{
    public Guid Id { get; set; }
    public int PageCount { get; set; }
    public DateTime CreatedDateTime { get; set; }
    
    public Guid UserId { get; set; }
    public string BookId { get; set; } = string.Empty;
    public UserBook? UserBook { get; set; }
}
