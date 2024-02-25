using BookTracker.BusinessLogic.Features.Commands.VerifyUser;
using BookTracker.Private.Api.Contracts.VerifyUser;
using Riok.Mapperly.Abstractions;

namespace BookTracker.Private.Api.Endpoints.Users.VerifyUser;

[Mapper]
public static partial class VerifyUserEndpointMapper
{
    public static partial VerifyUserCommand ToCommand(this VerifyUserRequest request);
}