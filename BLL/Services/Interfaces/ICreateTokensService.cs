using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BLL.Services.Interfaces;

public interface ICreateTokensService
{
    public JwtSecurityToken CreateToken(List<Claim> authClaims);
}