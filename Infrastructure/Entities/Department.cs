using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Infrastructure.Entities;

public class Department : TrackingData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(300)]
    public string Description { get; set; }

    public ICollection<EmployeeDetails> EmployeesDetails { get; set; }
}
