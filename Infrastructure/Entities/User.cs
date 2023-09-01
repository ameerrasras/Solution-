using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;
#nullable disable

public class User : TrackingData
{
    [Key]
    public int Id { get; set; } // Primary Key
    public string UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    public UserRole UserRole { get; set; } // Navigation property

}