using AutoMapper;
using BLL.Models.Input.CupboardClothesInput;
using BLL.Models.Output.CupboardClothesOutput;
using BLL.Models.Output.ProcedureOutput;
using BLL.Services.Interfaces;
using DAL.Contracts.Finders;
using DAL.Contracts.Procedures;
using DAL.Contracts.Repositories;
using DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace BLL.Services;

public class CupboardClothesService : ICupboardClothesService
{
    private readonly ICupboardClothesRepository _clothesRepository;
    private readonly IConfiguration _configuration;
    private readonly ICupboardClothesFinder _cupboardClothesFinder;
    private readonly IMapper _mapper;
    private readonly IProcedureProcessor _procedureProcessor;


    public CupboardClothesService(ICupboardClothesRepository clothesRepository,
        ICupboardClothesFinder cupboardClothesFinder, IProcedureProcessor procedureProcessor,
        IConfiguration configuration, IMapper mapper)
    {
        _clothesRepository = clothesRepository;
        _cupboardClothesFinder = cupboardClothesFinder;
        _procedureProcessor = procedureProcessor;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCupboardClothes entity, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardClothes>(entity);
        await _clothesRepository.Create(mappedData, token);
    }

    public async Task DeleteAsync(DeleteCupboardClothes entity, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardClothes>(entity);
        await _clothesRepository.Delete(mappedData, token);
    }

    public async Task UpdateAsync(UpdateCupboardClothes entity, CancellationToken token)
    {
        var mappedData = _mapper.Map<CupboardClothes>(entity);
        await _clothesRepository.Update(mappedData, token);
    }

    public async Task<GetCupboardClothesOutput?> GetByIdAsync(Guid id, CancellationToken token)
    {
        var mappedData = _mapper.Map<GetCupboardClothesOutput>(await _cupboardClothesFinder.GetByIdAsync(id, token));
        return mappedData;
    }

    public async Task<List<GetCupboardClothesOutput>> GetAsync(CancellationToken token)
    {
        var data = await _cupboardClothesFinder.GetAsync(token);
        var mappedData = _mapper.Map<List<GetCupboardClothesOutput>>(data);
        return mappedData;
    }

    public IEnumerable<ProcedureOutput> ExecuteProcedure()
    {
        var connection = _configuration.GetConnectionString("DefaultConnection");

        return _mapper.Map<IEnumerable<ProcedureOutput>>(_procedureProcessor.GetDataFromProcedure(connection));
    }
}