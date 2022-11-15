namespace DAL.Contracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken token);
}