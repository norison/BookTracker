using AutoFixture;
using BookTracker.BusinessLogic.Features.Commands.AddUser;
using BookTracker.BusinessLogic.Features.Commands.VerifyUser;
using BookTracker.Private.Api.Contracts.AddUser;
using BookTracker.Private.Api.Contracts.VerifyUser;
using BookTracker.Private.Api.Controllers;
using FluentAssertions;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace BookTracker.Private.Api.Tests.Controllers;

public class UsersControllerTests : TestBase
{
    private ISender _sender = null!;
    private UsersController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _sender = Substitute.For<ISender>();
        _controller = new UsersController(_sender);
    }

    [Test]
    public async Task AddUserAsync_WhenCalled_ShouldSendAddUserCommand()
    {
        // Arrange
        var request = Fixture.Create<AddUserRequest>();

        // Act
        var response = await _controller.AddUserAsync(request, CancellationToken.None);

        // Assert
        await _sender
            .Received()
            .Send(Verify.That<AddUserCommand>(command => command.Should().BeEquivalentTo(request)));
        
        response.Should().BeOfType<NoContentResult>();
    }
    
    [Test]
    public async Task VerifyUserAsync_WhenCalled_ShouldSendVerifyUserCommand()
    {
        // Arrange
        var request = Fixture.Create<VerifyUserRequest>();

        // Act
        var response = await _controller.VerifyUserAsync(request, CancellationToken.None);

        // Assert
        await _sender
            .Received()
            .Send(Verify.That<VerifyUserCommand>(command => command.Should().BeEquivalentTo(request)));
        
        response.Should().BeOfType<NoContentResult>();
    }
}