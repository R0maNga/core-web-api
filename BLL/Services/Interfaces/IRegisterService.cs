using BLL.Models.Output.AuthOutput;
using BLL.Models.Output.RegisterServiceOutput;

namespace BLL.Services.Interfaces;

public interface IRegisterService
{
    public Task<RegisterServiceOutput> RegisterLogic(RegisterModelOutput model);
}