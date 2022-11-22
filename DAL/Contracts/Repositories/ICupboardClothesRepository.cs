using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface ICupboardClothesRepository
{
    Task<int> Create(CupboardClothes cupboardClothes, CancellationToken token);
    Task<int> Update(CupboardClothes cupboardClothes, CancellationToken token);
    Task<int> Delete(CupboardClothes cupboardClothes, CancellationToken token);
}