using BLL.Models.Output.AuthOutput;
using BLL.Models.Output.LoginServiceOutput;

namespace BLL.Services.Interfaces;

public interface ILoginService
{
    public Task<LoginServiceOutput> LoginLogic(LoginModelOutput model);
}