namespace Business.Models;
#nullable disable
public class UserModel 
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}