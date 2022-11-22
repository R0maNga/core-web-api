using System.Security.Claims;

namespace BLL.Services.Interfaces;

public interface IGetPrincipalFromExpiredToken
{
    public ClaimsPrincipal? GetPrincipalFromToken(string? token);
}