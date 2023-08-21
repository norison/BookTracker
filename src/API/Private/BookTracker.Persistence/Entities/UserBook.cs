namespace BookTracker.Persistence.Entities;

public class UserBook
{
    public string Id { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public int PageCount { get; set; }
    public DateTime DesiredFinishDate { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }

    public Book? Book { get; set; }
    public User? User { get; set; }
    
    public IEnumerable<UserBookTracker>? UserBookTrackers { get; set; }
}
