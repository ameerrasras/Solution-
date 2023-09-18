using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Infrastructure.Entities;

public class User : TrackingData
{
    [Key]
    public int Id { get; set; } 
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    public UserDetails UserDetails { get; set; }
    public EmployeeDetails EmployeeDetails { get; set; }

}