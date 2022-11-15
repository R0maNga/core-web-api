using AutoMapper;
using BLL.Models.Input.CupboardModelnput;
using BLL.Models.Output.CupboardModelOutput;
using BLL.Services.Interfaces;
using DAL.Contracts;
using DAL.Contracts.Finders;
using DAL.Contracts.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class CupboardModelService : ICupboardModelService
{
    private readonly ICupboardModelFinder _cupboardModelFinder;
    private readonly ICupboardModelRepository _cupboardRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public CupboardModelService(ICupboardModelRepository cupboardRepository, IUnitOfWork unitOfWork,
        ICupboardModelFinder cupboardModelFinder, IMapper mapper)
    {
        _cupboardRepository = cupboardRepository;
        _unitOfWork = unitOfWork;
        _cupboardModelFinder = cupboardModelFinder;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCupboardModel model, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardModel>(model);
        _cupboardRepository.Create(mappedData);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(DeleteCupboardModel model, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardModel>(model);
        _cupboardRepository.Delete(mappedData);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(UpdateCupboardModel model, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardModel>(model);
        _cupboardRepository.Update(mappedData);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task<List<GetCupboardModelOutput>> GetAsync(CancellationToken token, bool includeCupboard = true)
    {
        var data =
            _mapper.Map<List<GetCupboardModelOutput>>(
                await _cupboardModelFinder.GetAsync(token, includeCupboard));
        return data;
    }
}