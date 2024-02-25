using AutoFixture;
using BookTracker.BusinessLogic.Features.Commands.VerifyUser;
using BookTracker.Private.Api.Contracts.VerifyUser;
using BookTracker.Private.Api.Endpoints.Users.VerifyUser;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using NSubstitute;
using PAP.NSubstitute.FluentAssertionsBridge;

namespace BookTracker.Private.Api.Tests.Endpoints.Users;

public class VerifyUserEndpointTests : EndpointTestBase
{
    [Test]
    public void RegisterEndpoint_WhenCalled_ShouldRegisterVerifyUserEndpoint()
    {
        // Arrange
        var endpointRouteBuilder = Substitute.For<IEndpointRouteBuilder>();
        var endpoint = new VerifyUserEndpoint();

        // Act
        endpoint.RegisterEndpoint(endpointRouteBuilder);

        // Assert
        endpointRouteBuilder
            .Received()
            .MapPost("users/verify", VerifyUserEndpoint.VerifyUserAsync);
    }
    
    [Test]
    public async Task VerifyUserAsync_WhenCalled_ShouldSendVerifyUserCommand()
    {
        // Arrange
        var request = Fixture.Create<VerifyUserRequest>();

        // Act
        var response = await VerifyUserEndpoint.VerifyUserAsync(Sender, request, CancellationToken.None);
        
        // Assert
        await Sender
            .Received()
            .Send(Verify.That<VerifyUserCommand>(command => command.Should().BeEquivalentTo(request)));
        
        response.Should().BeOfType<NoContent>();
    }
}