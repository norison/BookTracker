using AutoFixture;

namespace BookTracker.Private.Api.Tests;

[TestFixture]
public abstract class TestBase
{
    protected Fixture Fixture { get; } = new Fixture();
}