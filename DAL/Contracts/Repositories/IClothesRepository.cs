using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface IClothesRepository
{
    void Create(Clothes clothes);
    void Update(Clothes clothes);
    void Delete(Clothes clothes);
}