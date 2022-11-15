using DAL.Contracts.Repositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CupboardClothesRepository : AbtractRepository<CupboardClothes>, ICupboardClothesRepository
{
    public CupboardClothesRepository(DbSet<CupboardClothes> dbSet) : base(dbSet)
    {
    }
}