namespace BookTracker.Persistence.Entities;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }
    public int PublishedYear { get; set; }
    public int PageCount { get; set; }

    public int PublisherId { get; set; }
    public Publisher? Publisher { get; set; }
    
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    public string LanguageId { get; set; } = string.Empty;
    public Language? Language { get; set; }
    
    public IEnumerable<BookAuthor>? BookAuthors { get; set; }
    public IEnumerable<UserBook>? UserBooks { get; set; }
}
