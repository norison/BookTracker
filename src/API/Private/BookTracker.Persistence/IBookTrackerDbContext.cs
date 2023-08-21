using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Persistence;

public interface IBookTrackerDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Publisher> Publishers { get; set; }
    DbSet<BookAuthor> BookAuthors { get; set; }
    DbSet<Mood> Moods { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserBook> UserBooks { get; set; }
    DbSet<UserBookStatus> UserBookStatuses { get; set; }
    DbSet<UserBookTracker> UserBookTrackers { get; set; }
    DbSet<Language> Languages { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
