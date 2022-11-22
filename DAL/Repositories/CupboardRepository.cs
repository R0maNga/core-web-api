using DAL.Contracts.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class CupboardRepository : AbtractRepository<Cupboard>, ICupboardRepository
{
    public CupboardRepository(CupboardContext context) : base(context)
    {
    }
}