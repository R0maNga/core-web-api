using DAL.Contracts.Finders;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders;

public class CupboardModelFinder : ICupboardModelFinder
{
    private readonly DbSet<CupboardModel> _dbSet;

    public CupboardModelFinder(DbSet<CupboardModel> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task<List<CupboardModel>> GetAsync(CancellationToken token, bool includeCupboard = false)
    {
        var res = AsQueryable();
        res = includeCupboard
            ? res.Include(t => t.Cupboards)
            : res;

        return res.ToListAsync(token);
    }

    protected IQueryable<CupboardModel> AsQueryable()
    {
        return _dbSet.AsQueryable();
    }
}