using System.Security.Cryptography;
using BLL.Services.Interfaces;

namespace BLL.Services;

public class GenerateRefreshToken : IGenerateRefreshToken
{
    public string GenerateRefresh()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}