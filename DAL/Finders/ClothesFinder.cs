using DAL.Contracts.Finders;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders;

public class ClothesFinder : IClothesFinder
{
    private readonly DbSet<Clothes> _dbSet;

    public ClothesFinder(DbSet<Clothes> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task<List<Clothes>> GetAsync(CancellationToken token)
    {
        var res = AsQueryable();

        return res.ToListAsync(token);
    }

    public Task<Clothes?> GetByIdAsync(Guid id, CancellationToken token)
    {
        var res = AsQueryable().AsNoTracking();
        return res.FirstOrDefaultAsync(x => x.Id == id, token);
    }

    protected IQueryable<Clothes> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}