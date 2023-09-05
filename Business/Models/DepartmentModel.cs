using System.ComponentModel.DataAnnotations;

namespace Business.Models;
#nullable disable
public class DepartmentModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
}

    