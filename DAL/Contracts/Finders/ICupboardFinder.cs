using DAL.Entities;

namespace DAL.Contracts.Finders;

public interface ICupboardFinder
{
    public Task<List<Cupboard>> GetAsync(CancellationToken token, bool includeModel = false);
    public Task<Cupboard?> GetByIdAsync(Guid id, CancellationToken token, bool includeModel = false);
}