using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface ICupboardClothesRepository
{
    void Create(CupboardClothes cupboardClothes);
    void Update(CupboardClothes cupboardClothes);
    void Delete(CupboardClothes cupboardClothes);
}