using DAL.Contracts.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class ClothesRepository : AbtractRepository<Clothes>, IClothesRepository
{
    public ClothesRepository(CupboardContext context) : base(context)
    {
    }
}