namespace Business.Models;

public class UserModel 
{
#nullable disable
    public string UserId { get; set; }
    public int RoleId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

