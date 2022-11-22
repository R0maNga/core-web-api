using System.IdentityModel.Tokens.Jwt;

namespace BLL.Models.Output.LoginServiceOutput;

public class LoginServiceOutput
{
    public string RefreshToken { get; set; }
    public JwtSecurityToken Token { get; set; }
    public DateTime TokenExpireDateTime { get; set; }
}