using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface IClothesRepository
{
    Task<int> Create(Clothes clothes, CancellationToken token);
    Task<int> Update(Clothes clothes, CancellationToken token);
    Task<int> Delete(Clothes clothes, CancellationToken token);
}