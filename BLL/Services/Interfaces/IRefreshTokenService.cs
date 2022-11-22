using BLL.Models.Output.AuthOutput;
using BLL.Models.Output.RefreshTokenServiceOutput;

namespace BLL.Services.Interfaces;

public interface IRefreshTokenService
{
    Task<RefreshTokenServiceOutput?> CreateRefreshToken(TokenModelOutput tokenModel);
}