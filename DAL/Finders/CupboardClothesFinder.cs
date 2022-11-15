using DAL.Contracts.Finders;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders;

public class CupboardClothesFinder : ICupboardClothesFinder
{
    private readonly DbSet<CupboardClothes> _dbSet;

    public CupboardClothesFinder(DbSet<CupboardClothes> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task<List<CupboardClothes>> GetAsync(CancellationToken token)
    {
        var res = AsQueryable();

        return res.ToListAsync(token);
    }

    public Task<CupboardClothes?> GetByIdAsync(Guid id, CancellationToken token)
    {
        var res = AsQueryable().AsNoTracking();
        return res.FirstOrDefaultAsync(x => x.Id == id, token);
    }

    protected IQueryable<CupboardClothes> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}