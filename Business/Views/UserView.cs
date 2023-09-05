using Infrastructure.Entities;
namespace Business.Views;
#nullable disable
public class UserView : TrackingData
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
}
