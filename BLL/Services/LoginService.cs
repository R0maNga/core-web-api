using System.Security.Claims;
using BLL.Models.Output.AuthOutput;
using BLL.Models.Output.LoginServiceOutput;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BLL.Services;

public class LoginService : ILoginService
{
    private readonly IConfiguration _configuration;
    private readonly ICreateTokensService _createTokens;
    private readonly IGenerateRefreshToken _generateRefreshToken;
    private readonly UserManager<AppUser> _userManager;


    public LoginService(UserManager<AppUser> userManager, IConfiguration configuration,
        ICreateTokensService createTokens, IGenerateRefreshToken generateRefreshToken)
    {
        _userManager = userManager;
        _configuration = configuration;
        _createTokens = createTokens;
        _generateRefreshToken = generateRefreshToken;
    }


    public async Task<LoginServiceOutput> LoginLogic(LoginModelOutput model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles) authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var token = _createTokens.CreateToken(authClaims);
            var refreshToken = _generateRefreshToken.GenerateRefresh();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out var refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);

            var res = new LoginServiceOutput();
            res.Token = token;
            res.RefreshToken = refreshToken;
            return res;
        }

        return null;
    }
}