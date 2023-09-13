using BookTracker.BusinessLogic.Exceptions.Base;

namespace BookTracker.BusinessLogic.Exceptions.User;

public class UserAlreadyExistsException : NotFoundException
{
    private const string ErrorMessage = "User already exists";

    public UserAlreadyExistsException() : base(ErrorMessage)
    {
    }

    public override int Code => (int)UserCode.UserAlreadyExists;
}
