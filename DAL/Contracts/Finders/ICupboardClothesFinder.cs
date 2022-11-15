using DAL.Entities;

namespace DAL.Contracts.Finders;

public interface ICupboardClothesFinder
{
    public Task<List<CupboardClothes>> GetAsync(CancellationToken token);
    public Task<CupboardClothes?> GetByIdAsync(Guid id, CancellationToken token);
}