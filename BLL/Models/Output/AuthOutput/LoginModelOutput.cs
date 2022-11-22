using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Output.AuthOutput;

public class LoginModelOutput
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}