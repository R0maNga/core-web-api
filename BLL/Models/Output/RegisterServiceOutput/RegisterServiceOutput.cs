using BLL.Models.Output.AuthOutput;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Models.Output.RegisterServiceOutput;

public class RegisterServiceOutput
{
    public UserOutput UserOutput { get; set; }
    public IdentityResult Result { get; set; }
}