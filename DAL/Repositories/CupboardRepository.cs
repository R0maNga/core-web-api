using DAL.Contracts.Repositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CupboardRepository : AbtractRepository<Cupboard>, ICupboardRepository
{
    public CupboardRepository(DbSet<Cupboard> dbSet) : base(dbSet)
    {
    }
}