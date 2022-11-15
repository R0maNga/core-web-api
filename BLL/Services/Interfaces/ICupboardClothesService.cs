using BLL.Models.Input.CupboardClothesInput;
using BLL.Models.Output.CupboardClothesOutput;
using BLL.Models.Output.ProcedureOutput;

namespace BLL.Services.Interfaces;

public interface ICupboardClothesService
{
    public Task CreateAsync(CreateCupboardClothes model, CancellationToken token);
    public Task DeleteAsync(DeleteCupboardClothes model, CancellationToken token);
    public Task UpdateAsync(UpdateCupboardClothes model, CancellationToken token);
    public Task<GetCupboardClothesOutput?> GetByIdAsync(Guid id, CancellationToken token);
    public Task<List<GetCupboardClothesOutput>> GetAsync(CancellationToken token);
    public IEnumerable<ProcedureOutput> ExecuteProcedure();
}