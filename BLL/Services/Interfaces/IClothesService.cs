using BLL.Models.Input.ClothesInput;
using BLL.Models.Output.CLothesOutput;

namespace BLL.Services.Interfaces;

public interface IClothesService
{
    public Task CreateAsync(CreateClothes model, CancellationToken token);
    public Task DeleteAsync(DeleteClothes model, CancellationToken token);
    public Task UpdateAsync(UpdateClothes model, CancellationToken token);
    public Task<GetCLothesOutput?> GetByIdAsync(Guid id, CancellationToken token);
    public Task<List<GetCLothesOutput>> GetAsync(CancellationToken token);
}