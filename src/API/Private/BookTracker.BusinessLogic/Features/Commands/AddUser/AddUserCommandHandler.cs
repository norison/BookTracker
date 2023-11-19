using BookTracker.BusinessLogic.Exceptions.User;
using BookTracker.BusinessLogic.Services.Password;
using BookTracker.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.BusinessLogic.Features.Commands.AddUser;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
{
    private readonly IDbContextFactory<BookTrackerDbContext> _contextFactory;
    private readonly IPasswordService _passwordService;

    public AddUserCommandHandler(
        IDbContextFactory<BookTrackerDbContext> contextFactory,
        IPasswordService passwordService)
    {
        _contextFactory = contextFactory;
        _passwordService = passwordService;
    }

    public async ValueTask<Unit> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        
        var user = await context.Users.FirstOrDefaultAsync(
            x => x.Login == command.Login || x.Email == command.Email,
            cancellationToken);

        if (user is not null)
        {
            throw new UserAlreadyExistsException();
        }

        var passwordHash = _passwordService.HashPassword(command.Password);
        var newUser = command.ToUser(passwordHash);

        await context.Users.AddAsync(newUser, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}