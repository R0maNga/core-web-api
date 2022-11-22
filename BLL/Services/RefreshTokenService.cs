using AutoMapper;
using BLL.Models.Output.AuthOutput;
using BLL.Models.Output.RefreshTokenServiceOutput;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ICreateTokensService _createTokens;
    private readonly IGenerateRefreshToken _generateRefreshToken;
    private readonly IGetPrincipalFromExpiredToken _getPrincipalFromExpiredToken;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public RefreshTokenService(IGetPrincipalFromExpiredToken getPrincipalFromExpiredToken,
        UserManager<AppUser> userManager,
        ICreateTokensService createTokens, IGenerateRefreshToken generateRefreshToken, IMapper mapper)
    {
        _getPrincipalFromExpiredToken = getPrincipalFromExpiredToken;
        _userManager = userManager;
        _createTokens = createTokens;
        _generateRefreshToken = generateRefreshToken;
        _mapper = mapper;
    }

    public async Task<RefreshTokenServiceOutput?> CreateRefreshToken(TokenModelOutput tokenModel)
    {
        var accessToken = tokenModel.AccessToken;
        var refreshToken = tokenModel.RefreshToken;

        var principal = _getPrincipalFromExpiredToken.GetPrincipalFromToken(accessToken);
        var username = principal.Identity.Name;

        var user = await _userManager.FindByNameAsync(username);
        if (user == null || user.RefreshToken != refreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now) return null;
        var newAccessToken = _createTokens.CreateToken(principal.Claims.ToList());
        var newRefreshToken = _generateRefreshToken.GenerateRefresh();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);
        var refreshTokenServiceOutput = new RefreshTokenServiceOutput();

        var mappedUser = _mapper.Map<UserOutput>(user);
        refreshTokenServiceOutput.User = mappedUser;
        refreshTokenServiceOutput.ClaimsPrincipal = principal;
        refreshTokenServiceOutput.NewAccessToken = newAccessToken;
        refreshTokenServiceOutput.NewRefreshToken = newRefreshToken;
        return refreshTokenServiceOutput;
    }
}