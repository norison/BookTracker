using BookTracker.BusinessLogic.Enums;
using BookTracker.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace BookTracker.BusinessLogic.Features.Commands.AddUser;

[Mapper]
public static partial class AddUserMapper
{
    public static User ToUser(this AddUserCommand command, string passwordHash)
    {
        var user = command.ToUserInternal();
        user.PasswordHash = passwordHash;
        user.RoleId = (int)RoleType.User;
        return user;
    }
    
    private static partial User ToUserInternal(this AddUserCommand command);
}
