using AutoFixture;
using BookTracker.BusinessLogic.Features.Commands.AddUser;
using BookTracker.Private.Api.Contracts.AddUser;
using BookTracker.Private.Api.Endpoints.Users.AddUser;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace BookTracker.Private.Api.Tests.Endpoints.Users;

public class AddUserEndpointTests : EndpointTestBase
{
    [Test]
    public void RegisterEndpoint_WhenCalled_ShouldRegisterAddUserEndpoint()
    {
        // Arrange
        var endpointRouteBuilder = Substitute.For<IEndpointRouteBuilder>();
        var endpoint = new AddUserEndpoint();

        // Act
        endpoint.RegisterEndpoint(endpointRouteBuilder);

        // Assert
        endpointRouteBuilder
            .Received()
            .MapPost("users/add", AddUserEndpoint.AddUserAsync);
    }
    
    [Test]
    public async Task AddUserAsync_WhenCalled_ShouldSendAddUserCommand()
    {
        // Arrange
        var request = Fixture.Create<AddUserRequest>();

        // Act
        var response = await AddUserEndpoint.AddUserAsync(Sender, request, CancellationToken.None);

        // Assert
        await Sender
            .Received()
            .Send(Verify.That<AddUserCommand>(command => command.Should().BeEquivalentTo(request)));

        response.Should().BeOfType<NoContent>();
    }
}