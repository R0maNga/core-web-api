using BLL.Models.Input.CupboardModelnput;
using BLL.Models.Output.CupboardModelOutput;

namespace BLL.Services.Interfaces;

public interface ICupboardModelService
{
    public Task CreateAsync(CreateCupboardModel model, CancellationToken token);
    public Task DeleteAsync(DeleteCupboardModel model, CancellationToken token);
    public Task UpdateAsync(UpdateCupboardModel model, CancellationToken token);
    Task<List<GetCupboardModelOutput>> GetAsync(CancellationToken token, bool includeCupboard = false);
}