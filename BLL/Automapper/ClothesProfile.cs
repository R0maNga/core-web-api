using AutoMapper;
using BLL.Models.Input.ClothesInput;
using BLL.Models.Output.CLothesOutput;
using DAL.Entities;

namespace BLL.Automapper;

public class ClothesProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeleteClothes, Clothes>();
            CreateMap<CreateClothes, Clothes>();
            CreateMap<UpdateClothes, Clothes>();
            CreateMap<GetCLothesOutput, UpdateClothes>();
            CreateMap<Clothes, GetCLothesOutput>();
        }
    }
}