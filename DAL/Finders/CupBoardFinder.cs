using DAL.Contracts.Finders;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders;

public class CupBoardFinder : ICupboardFinder
{
    private readonly DbSet<Cupboard> _dbSet;

    public CupBoardFinder(DbSet<Cupboard> dbSet)
    {
        _dbSet = dbSet;
    }

    public Task<List<Cupboard>> GetAsync(
        CancellationToken token,
        bool includeModel = false
    )
    {
        var res = AsQuerable();
        res = includeModel
            ? res.Include(t => t.CupboardModel)
            : res;
        return res.ToListAsync(token);
    }

    public Task<Cupboard?> GetByIdAsync(Guid id, CancellationToken token, bool includeModel = false)
    {
        var res = AsQuerable().AsNoTracking();
        res = includeModel
            ? res.Include(t => t.CupboardModel)
            : res;
        return res.FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public IQueryable<Cupboard> AsQuerable()
    {
        return _dbSet.AsQueryable();
    }
}