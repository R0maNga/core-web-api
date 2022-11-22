using BLL.Models.Output.AuthOutput;

namespace BLL.Services.Interfaces;

public interface ICreateUserService
{
    public UserOutput Create(RegisterModelOutput model);
}