using BookTracker.BusinessLogic.Exceptions.User;
using BookTracker.BusinessLogic.Services.Password;
using BookTracker.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.BusinessLogic.Features.Commands.VerifyUser;

public class VerifyUserHandler : ICommandHandler<VerifyUserCommand>
{
    private readonly IDbContextFactory<BookTrackerDbContext> _contextFactory;
    private readonly IPasswordService _passwordService;

    public VerifyUserHandler(IDbContextFactory<BookTrackerDbContext> contextFactory, IPasswordService passwordService)
    {
        _contextFactory = contextFactory;
        _passwordService = passwordService;
    }

    public async ValueTask<Unit> Handle(VerifyUserCommand command, CancellationToken cancellationToken)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        
        var user = await context.Users.FirstOrDefaultAsync(
            x => x.Login == command.EmailOrLogin || x.Email == command.EmailOrLogin, cancellationToken);
        
        if (user is null || !_passwordService.VerifyPassword(command.Password, user.PasswordHash))
        {
            throw new InvalidCredentials();
        }

        return Unit.Value;
    }
}