using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface ICupboardModelRepository
{
    Task<int> Create(CupboardModel model, CancellationToken token);
    Task<int> Update(CupboardModel model, CancellationToken token);
    Task<int> Delete(CupboardModel model, CancellationToken token);
}