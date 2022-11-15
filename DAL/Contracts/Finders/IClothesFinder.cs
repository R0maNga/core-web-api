using DAL.Entities;

namespace DAL.Contracts.Finders;

public interface IClothesFinder
{
    public Task<List<Clothes>> GetAsync(CancellationToken token);
    public Task<Clothes?> GetByIdAsync(Guid id, CancellationToken token);
}