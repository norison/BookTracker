namespace BookTracker.Persistence.Entities;

public class AuthorBook : AuditEntity
{
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public Author? Author { get; set; }
    public Book? Book { get; set; }
}