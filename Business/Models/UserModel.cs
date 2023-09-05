using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Business.Models;

public class UserModel
{
    [Required]
    public int RoleId { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"(?=.*\d).{6,}", ErrorMessage = "Minimum 6 charachters, at least one digit")]
    public string Password { get; set; }
}