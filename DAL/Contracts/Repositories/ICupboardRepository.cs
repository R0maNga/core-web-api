using DAL.Entities;

namespace DAL.Contracts.Repositories;

public interface ICupboardRepository
{
    void Create(Cupboard cupboard);
    void Update(Cupboard cupboard);
    void Delete(Cupboard cupboard);
}