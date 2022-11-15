using DAL.Contracts.Repositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CupboardModelRepository : AbtractRepository<CupboardModel>, ICupboardModelRepository
{
    public CupboardModelRepository(DbSet<CupboardModel> dbSet) : base(dbSet)
    {
    }
}