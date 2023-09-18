using Infrastructure.Entities;
#nullable disable

namespace Business.Views;

public class DepartmentsView : TrackingData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

