using DAL.Contracts.Repositories;
using DAL.Entities;

namespace DAL.Repositories;

public class CupboardModelRepository : AbtractRepository<CupboardModel>, ICupboardModelRepository
{
    public CupboardModelRepository(CupboardContext context) : base(context)
    {
    }
}