using BLL.Models.Output.AuthOutput;
using BLL.Services.Interfaces;

namespace BLL.Services;

public class CreateUserService : ICreateUserService
{
    public UserOutput Create(RegisterModelOutput model)
    {
        UserOutput user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        return user;
    }
}