using DAL.Entities;

namespace DAL.Contracts.Finders;

public interface ICupboardModelFinder
{
    public Task<List<CupboardModel>> GetAsync(CancellationToken token, bool includeCupboard = false);
}