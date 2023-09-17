using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Infrastructure.Entities;

public class UserDetails : TrackingData
{
    [Key]
    public int Id { get; set; }

    public string ProfilePictureUrl { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; }

    [Required]
    [MaxLength(15)]
    public string Tel { get; set; }
}
