using BookTracker.Private.Api.Contracts.AddUser;
using Mediator;

namespace BookTracker.Private.Api.Endpoints.Users.AddUser;

public class AddUserEndpoint : IEndpointRegister
{
    public void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("users/add", AddUserAsync);
    }

    public static async Task<IResult> AddUserAsync(
        ISender sender,
        AddUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        await sender.Send(command, cancellationToken);
        return Results.NoContent();
    }
}