namespace DAL.Repositories;

public abstract class AbtractRepository<T> where T : class
{
    private readonly CupboardContext _context;

    protected AbtractRepository(CupboardContext context)
    {
        _context = context;
    }

    public virtual Task<int> Create(T item, CancellationToken token)
    {
        _context.Add(item);
        return _context.SaveChangesAsync(token);
    }


    public virtual Task<int> Update(T item, CancellationToken token)
    {
        _context.Update(item);
        return _context.SaveChangesAsync(token);
    }

    public virtual Task<int> Delete(T item, CancellationToken token)
    {
        _context.Remove(item);
        return _context.SaveChangesAsync(token);
    }
}