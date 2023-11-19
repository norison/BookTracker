using BookTracker.BusinessLogic.Exceptions.Base;

namespace BookTracker.BusinessLogic.Exceptions.User;

public class InvalidCredentials : ValidationException
{
    private const string ErrorMessage = "Email/Login or password is incorrect";

    public InvalidCredentials() : base(ErrorMessage)
    {
    }
    
    public override int Code => (int)UserCode.InvalidCredentials;
}