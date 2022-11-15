using BLL.Models.Input.CupboardInput;
using BLL.Models.Output.CupboardOutput;

namespace BLL.Services.Interfaces;

public interface ICupboardService
{
    public Task CreateAsync(CreateCupboard model, CancellationToken token);
    public Task DeleteAsync(DeleteCupboard model, CancellationToken token);
    public Task UpdateAsync(UpdateCupboard model, CancellationToken token);
    public Task<List<GetCupboardOutput>> GetAsync(CancellationToken token, bool includeModel = false);
    public Task<GetCupboardOutput?> GetByIdAsync(Guid id, CancellationToken token, bool includeModel = false);
}