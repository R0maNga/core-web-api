using DAL.Contracts.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class CupboardClothesRepository : AbtractRepository<CupboardClothes>, ICupboardClothesRepository
{
    public CupboardClothesRepository(CupboardContext context) : base(context)
    {
    }
}