using BLL.Models.Output.AuthOutput;

namespace BLL.Services.Interfaces;

public interface IRegisterAdminService
{
    public Task CreateAdmin(RegisterModelOutput model);
}