using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface ICupboardRepository
{
    Task<int> Create(Cupboard cupboard, CancellationToken token);
    Task<int> Update(Cupboard cupboard, CancellationToken token);
    Task<int> Delete(Cupboard cupboard, CancellationToken token);
}