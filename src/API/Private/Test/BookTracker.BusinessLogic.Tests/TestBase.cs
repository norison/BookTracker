using AutoFixture;
using BookTracker.Persistence;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace BookTracker.BusinessLogic.Tests;

[TestFixture]
public abstract class TestBase
{
    protected IDbContextFactory<BookTrackerDbContext> DbContextFactory { get; private set; } = null!;
    protected BookTrackerDbContext DbContext { get; private set; } = null!;
    protected Fixture Fixture { get; } = new();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Fixture.Behaviors
            .OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(b => Fixture.Behaviors.Remove(b));

        Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [SetUp]
    public virtual void SetUp()
    {
        var options = new DbContextOptionsBuilder<BookTrackerDbContext>().UseInMemoryDatabase("BookTracker").Options;
        DbContext = new BookTrackerDbContext(options);
        DbContext.Database.EnsureCreated();

        DbContextFactory = Substitute.For<IDbContextFactory<BookTrackerDbContext>>();
        DbContextFactory
            .CreateDbContextAsync(Arg.Any<CancellationToken>())
            .Returns(new BookTrackerDbContext(options));
    }
    
    [TearDown]
    public virtual void TearDown()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Dispose();
    }
}