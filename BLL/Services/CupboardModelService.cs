using AutoMapper;
using BLL.Models.Input.CupboardModelnput;
using BLL.Models.Output.CupboardModelOutput;
using BLL.Services.Interfaces;
using DAL.Contracts.Finders;
using DAL.Contracts.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class CupboardModelService : ICupboardModelService
{
    private readonly ICupboardModelFinder _cupboardModelFinder;
    private readonly ICupboardModelRepository _cupboardRepository;
    private readonly IMapper _mapper;


    public CupboardModelService(ICupboardModelRepository cupboardRepository,
        ICupboardModelFinder cupboardModelFinder, IMapper mapper)
    {
        _cupboardRepository = cupboardRepository;
        _cupboardModelFinder = cupboardModelFinder;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCupboardModel model, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardModel>(model);
        await _cupboardRepository.Create(mappedData, token);
    }

    public async Task DeleteAsync(DeleteCupboardModel model, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardModel>(model);
        await _cupboardRepository.Delete(mappedData, token);
    }

    public async Task UpdateAsync(UpdateCupboardModel model, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardModel>(model);
        await _cupboardRepository.Update(mappedData, token);
    }

    public async Task<List<GetCupboardModelOutput>> GetAsync(CancellationToken token, bool includeCupboard = true)
    {
        var data =
            _mapper.Map<List<GetCupboardModelOutput>>(
                await _cupboardModelFinder.GetAsync(token, includeCupboard));
        return data;
    }
}