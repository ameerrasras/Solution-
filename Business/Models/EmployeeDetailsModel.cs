using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Infrastructure.Entities;

public class EmployeeDetailsModel
{
    [Required(ErrorMessage = "Department ID is required.")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "User ID is required.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Salary is required.")]
    [Range(0, 1000000, ErrorMessage = "Salary must be between 0 and 1,000,000.")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    public DateTime EndDate { get; set; }
}
