
using Infrastructure.Identity;
using System.ComponentModel.DataAnnotations;
namespace Application.Register;

public class Register
{
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public Roles Role { get; set; } = Roles.User;
}
