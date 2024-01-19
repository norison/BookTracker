using FluentValidation;

namespace BookTracker.BusinessLogic.Features.Commands.VerifyUser;

public class VerifyUserCommandValidator : AbstractValidator<VerifyUserCommand>
{
    public VerifyUserCommandValidator()
    {
        RuleFor(command => command.EmailOrLogin).NotEmpty().MinimumLength(2);
        RuleFor(command => command.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}