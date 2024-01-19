using FluentValidation;

namespace BookTracker.BusinessLogic.Features.Commands.AddUser;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(command => command.Login).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(command => command.Email).NotEmpty().EmailAddress();
        RuleFor(command => command.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
        RuleFor(command => command.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(command => command.LastName).NotEmpty().MinimumLength(2).MaximumLength(50);
    }
}