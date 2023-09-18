using Infrastructure.Entities;
#nullable disable

namespace Business.Views;

public class UserRoleView : TrackingData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}