namespace BookTracker.Private.Api.Contracts.VerifyUser;

public class VerifyUserRequest
{
    public string EmailOrLogin { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}