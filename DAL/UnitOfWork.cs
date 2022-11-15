using DAL.Contracts;

namespace DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly CupboardContext _context;

    public UnitOfWork(CupboardContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken token)
    {
        return _context.SaveChangesAsync(token);
    }
}