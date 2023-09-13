namespace BookTracker.Persistence.Entities;

public class UserBookTracker
{
    public int Id { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime FinishedDateTime { set; get; }
    public int PageCount { get; set; }

    public long UserId { get; set; }
    public long BookId { get; set; }
    public UserBook? UserBook { get; set; }
}
