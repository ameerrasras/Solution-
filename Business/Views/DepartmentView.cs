using Infrastructure.Entities;
namespace Business.Views;

#nullable disable
public class DepartmentsView : TrackingData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

