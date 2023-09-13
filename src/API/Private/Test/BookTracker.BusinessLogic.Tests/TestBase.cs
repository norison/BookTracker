using AutoFixture;
using BookTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.BusinessLogic.Tests;

[TestFixture]
public abstract class TestBase
{
    protected BookTrackerDbContext DbContext { get; private set; } = null!;
    protected Fixture Fixture { get; } = new();

    [SetUp]
    public virtual void SetUp()
    {
        var options = new DbContextOptionsBuilder<BookTrackerDbContext>().UseInMemoryDatabase("BookTracker").Options;
        DbContext = new BookTrackerDbContext(options);
        DbContext.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }
}
