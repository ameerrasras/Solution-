using Infrastructure.Entities;
#nullable disable

namespace Business.Views;

public class UserView : TrackingData
{
    public int Id { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
}
