﻿using Microsoft.AspNetCore.Identity;

namespace DAL.Entities;

public class AppUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}