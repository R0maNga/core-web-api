using DAL.Contracts.Repositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ClothesRepository : AbtractRepository<Clothes>, IClothesRepository
{
    public ClothesRepository(DbSet<Clothes> dbSet) : base(dbSet)
    {
    }
}