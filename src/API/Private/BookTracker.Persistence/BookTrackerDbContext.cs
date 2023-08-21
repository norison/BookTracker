using BookTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Persistence;

public class BookTrackerDbContext : DbContext, IBookTrackerDbContext
{
    public BookTrackerDbContext(DbContextOptions<BookTrackerDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<BookAuthor> BookAuthors { get; set; } = null!;
    public DbSet<Mood> Moods { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserBook> UserBooks { get; set; } = null!;
    public DbSet<UserBookStatus> UserBookStatuses { get; set; } = null!;
    public DbSet<UserBookTracker> UserBookTrackers { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookTrackerDbContext).Assembly);
    }
}
