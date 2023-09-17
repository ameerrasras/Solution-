using Infrastructure.Entities;

#nullable disable

namespace Infrastructure.Views;

public class UserDetailsView : TrackingData
{
    public int Id { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Tel { get; set; }
}
