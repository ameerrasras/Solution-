using Infrastructure.Entities;
namespace Business.Views;
#nullable disable
public class UserRoleView : TrackingData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}