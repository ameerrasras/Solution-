using Infrastructure.Entities;
#nullable disable

namespace business.Views;

public class EmployeeDetailsView : TrackingData
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DepartmentId { get; set; }
    public int User { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}