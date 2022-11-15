using AutoMapper;
using BLL.Models.Input.ClothesInput;
using BLL.Models.Output.CLothesOutput;
using BLL.Services.Interfaces;
using DAL.Contracts;
using DAL.Contracts.Finders;
using DAL.Contracts.Repositories;
using DAL.Entities;

namespace BLL.Services;

public class ClothesService : IClothesService
{
    private readonly IClothesFinder _clothesFinder;
    private readonly IMapper _mapper;
    private readonly IClothesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public ClothesService(IClothesFinder clothesFinder, IUnitOfWork unitOfWork, IClothesRepository repository,
        IMapper mapper)
    {
        _mapper = mapper;
        _clothesFinder = clothesFinder;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task CreateAsync(CreateClothes model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Clothes>(model);
        _repository.Create(mappedData);
        await _unitOfWork.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(DeleteClothes model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Clothes>(model);
        _repository.Delete(mappedData);
        await _unitOfWork.SaveChangesAsync(token);
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

    public Task UpdateAsync(UpdateClothes model, CancellationToken token)
    {
        var mappedData = _mapper.Map<Clothes>(model);
        _repository.Update(mappedData);
        return _unitOfWork.SaveChangesAsync(token);
    }
}