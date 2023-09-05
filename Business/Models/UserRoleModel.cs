using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Business.Models;

public class UserRoleModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
}