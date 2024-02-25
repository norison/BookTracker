using Mediator;
using NSubstitute;

namespace BookTracker.Private.Api.Tests;

public abstract class EndpointTestBase : TestBase
{
    protected ISender Sender { get; private set; } = null!;

    [SetUp]
    public virtual void Setup()
    {
        Sender = Substitute.For<ISender>();
    }
}