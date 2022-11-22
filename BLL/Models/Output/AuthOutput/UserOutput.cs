namespace BLL.Models.Output.AuthOutput;

public class UserOutput
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public string UserName { get; set; }
    public string SecurityStamp { get; set; }
    public string Email { get; set; }
}