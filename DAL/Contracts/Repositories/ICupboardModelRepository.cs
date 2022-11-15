using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface ICupboardModelRepository
{
    void Create(CupboardModel model);
    void Update(CupboardModel model);
    void Delete(CupboardModel model);
}