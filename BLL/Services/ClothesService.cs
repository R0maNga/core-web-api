using AutoMapper;
using BLL.Models.Input.ClothesInput;
using BLL.Models.Output.CLothesOutput;
using BLL.Services.Interfaces;
using DAL.Contracts.Finders;
using DAL.Contracts.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class ClothesService : IClothesService
{
    private readonly IClothesFinder _clothesFinder;
    private readonly IMapper _mapper;
    private readonly IClothesRepository _repository;


    public ClothesService(IClothesFinder clothesFinder, IClothesRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _clothesFinder = clothesFinder;
        _repository = repository;
    }

    public async Task CreateAsync(CreateClothes model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Clothes>(model);
        await _repository.Create(mappedData, token);
    }

    public async Task DeleteAsync(DeleteClothes model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Clothes>(model);
        await _repository.Delete(mappedData, token);
    }

    public async Task<List<GetCLothesOutput>> GetAsync(CancellationToken token)
    {
        var data = await _clothesFinder.GetAsync(token);
        var mappedData = _mapper.Map<List<GetCLothesOutput>>(data);
        return mappedData;
    }

    public async Task<GetCLothesOutput?> GetByIdAsync(Guid id, CancellationToken token)
    {
        var clothes = _mapper.Map<GetCLothesOutput>(await _clothesFinder.GetByIdAsync(id, token));
        return clothes;
    }

    public async Task UpdateAsync(UpdateClothes model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Clothes>(model);
        await _repository.Update(mappedData, token);
    }
}