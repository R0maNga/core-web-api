using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Models.Output.AuthOutput;

namespace BLL.Models.Output.RefreshTokenServiceOutput;

public class RefreshTokenServiceOutput
{
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    public UserOutput User { get; set; }
    public JwtSecurityToken NewAccessToken { get; set; }
    public string NewRefreshToken { get; set; }
}