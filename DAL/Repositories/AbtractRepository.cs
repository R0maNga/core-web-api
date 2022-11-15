using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public abstract class AbtractRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public AbtractRepository(DbSet<T> dbSet)
    {
        _dbSet = dbSet;
    }

    public virtual void Create(T item)
    {
        _dbSet.Add(item);
    }


    public virtual void Update(T item)
    {
        _dbSet.Update(item);
    }

    public virtual void Delete(T item)
    {
        _dbSet.Remove(item);
    }
}