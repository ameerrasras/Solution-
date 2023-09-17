using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Infrastructure.Entities;

public class UserDetailsModel
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Profile picture URL is required.")]
    [Url(ErrorMessage = "Invalid URL format.")]
    public string ProfilePictureUrl { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Telephone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    public string Tel { get; set; }
}
