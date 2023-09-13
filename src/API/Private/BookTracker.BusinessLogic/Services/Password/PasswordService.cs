using System.Diagnostics.CodeAnalysis;

namespace BookTracker.BusinessLogic.Services.Password;

[ExcludeFromCodeCoverage]
public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(passwordHash, passwordHash);
    }
}
