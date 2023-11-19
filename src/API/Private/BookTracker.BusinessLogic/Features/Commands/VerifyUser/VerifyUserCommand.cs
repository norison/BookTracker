using Mediator;

namespace BookTracker.BusinessLogic.Features.Commands.VerifyUser;

public class VerifyUserCommand : ICommand
{
    public string EmailOrLogin { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}