using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Infrastructure.Entities;

public class EmployeeDetails : TrackingData
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Department Department { get; set; }

}
