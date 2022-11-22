using AutoMapper;
using BLL.Models.Input.CupboardInput;
using BLL.Models.Output.CupboardOutput;
using BLL.Services.Interfaces;
using DAL.Contracts.Finders;
using DAL.Contracts.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class CupboardService : ICupboardService
{
    private readonly ICupboardFinder _cupboardFinder;
    private readonly ICupboardRepository _cupboardRepository;
    private readonly IMapper _mapper;


    public CupboardService(ICupboardRepository repository, ICupboardFinder cupboardFinder,
        IMapper mapper)
    {
        _cupboardRepository = repository;
        _cupboardFinder = cupboardFinder;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCupboard model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Cupboard>(model);
        await _cupboardRepository.Create(mappedData, token);
    }

    public async Task DeleteAsync(DeleteCupboard model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Cupboard>(model);
        await _cupboardRepository.Delete(mappedData, token);
    }

    public async Task<List<GetCupboardOutput>> GetAsync(
        CancellationToken token,
        bool includeModel = false
    )
    {
        var mappedData =
            _mapper.Map<List<GetCupboardOutput>>(await _cupboardFinder.GetAsync(token, includeModel));
        return mappedData;
    }

    public async Task<GetCupboardOutput?> GetByIdAsync(Guid id, CancellationToken token, bool includeModel = false)
    {
        var mappedData = _mapper.Map<GetCupboardOutput>(await _cupboardFinder.GetByIdAsync(id, token, includeModel));
        return mappedData;
    }

    public async Task UpdateAsync(UpdateCupboard model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Cupboard>(model);
        await _cupboardRepository.Update(mappedData, token);
    }
}