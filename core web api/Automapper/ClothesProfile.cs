using AutoMapper;
using BLL.Models.Input.ClothesInput;
using BLL.Models.Output.CLothesOutput;
using core_web_api.Models.Request.ClothesRequest;
using core_web_api.Models.Response.ClothesResponse;

namespace core_web_api.Automapper;

public class ClothesProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClotheseDeleteRequest, DeleteClothes>();
            CreateMap<ClothesCreateRequest, CreateClothes>();
            CreateMap<ClotheseUpdateRequest, UpdateClothes>();
            CreateMap<GetCLothesOutput, GetClothesResponse>();
            CreateMap<UpdateClothes, GetCLothesOutput>();

            CreateMap<GetCLothesOutput, DeleteClothes>();
        }
    }
}