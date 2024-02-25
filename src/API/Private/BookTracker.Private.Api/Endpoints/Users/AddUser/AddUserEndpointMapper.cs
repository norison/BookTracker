using BookTracker.BusinessLogic.Features.Commands.AddUser;
using BookTracker.Private.Api.Contracts.AddUser;
using Riok.Mapperly.Abstractions;

namespace BookTracker.Private.Api.Endpoints.Users.AddUser;

[Mapper]
public static partial class AddUserEndpointMapper
{
    public static partial AddUserCommand ToCommand(this AddUserRequest request);
}