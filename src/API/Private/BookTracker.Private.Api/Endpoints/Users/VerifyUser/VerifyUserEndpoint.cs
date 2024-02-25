using BookTracker.Private.Api.Contracts.VerifyUser;
using Mediator;

namespace BookTracker.Private.Api.Endpoints.Users.VerifyUser;

public class VerifyUserEndpoint : IEndpointRegister
{
    public void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("users/verify", VerifyUserAsync);
    }

    public static async Task<IResult> VerifyUserAsync(
        ISender sender, 
        VerifyUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        await sender.Send(command, cancellationToken);
        return Results.NoContent();
    }
}