namespace BookTracker.Persistence.Entities;

public class User
{
    public long Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int RoleId { get; set; }
    public Role? Role { get; set; }
    
    public IEnumerable<UserBook>? UserBooks { get; set; }
}
