using AutoFixture;
using BookTracker.BusinessLogic.Enums;
using BookTracker.BusinessLogic.Exceptions.User;
using BookTracker.BusinessLogic.Features.Commands.AddUser;
using BookTracker.BusinessLogic.Services.Password;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace BookTracker.BusinessLogic.Tests.Features.Commands.AddUser;

public class AddUserCommandHandlerTests : TestBase
{
    private IPasswordService _passwordService = null!;
    private AddUserCommandHandler _handler = null!;
    
    public override void SetUp()
    {
        base.SetUp();
        
        _passwordService = Substitute.For<IPasswordService>();
        _handler = new AddUserCommandHandler(DbContext, _passwordService);
    }
    
    [Test]
    public async Task Handle_WhenUserDoesNotExist_ShouldAddUser()
    {
        // Arrange
        var passwordHash = Fixture.Create<string>();
        var command = Fixture.Create<AddUserCommand>();
        
        _passwordService.HashPassword(command.Password).Returns(passwordHash);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        var user = await DbContext.Users.FirstOrDefaultAsync(x => x.Login == command.Login);

        user.Should().NotBeNull();
        user.Should().BeEquivalentTo(command, options => options.Excluding(x => x.Password));
        user!.PasswordHash.Should().BeEquivalentTo(passwordHash);
        user.RoleId.Should().Be((int)RoleType.User);
    }

    [Test]
    public async Task Handle_WhenUserExists_ShouldThrowUserAlreadyExistsException()
    {
        // Arrange
        var passwordHash = Fixture.Create<string>();
        var command = Fixture.Create<AddUserCommand>();
        var user = command.ToUser(passwordHash);
        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();

        // Act & Assert
        await _handler
            .Invoking(async x => await x.Handle(command, CancellationToken.None))
            .Should()
            .ThrowExactlyAsync<UserAlreadyExistsException>();
    }
}
