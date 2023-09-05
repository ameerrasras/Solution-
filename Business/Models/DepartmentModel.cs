using System.ComponentModel.DataAnnotations;

namespace Business.Models;
#nullable disable
public class DepartmentModel
{
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
}

