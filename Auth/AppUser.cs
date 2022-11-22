using Microsoft.AspNetCore.Identity;

namespace Auth
{
    public class AppUser:IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        
    }
}