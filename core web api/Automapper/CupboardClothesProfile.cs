using AutoMapper;
using BLL.Models.Input.CupboardClothesInput;
using BLL.Models.Output.CupboardClothesOutput;
using core_web_api.Models.Request.CupboardClothesRequest;
using core_web_api.Models.Response.CupboardClothesResponse;

namespace core_web_api.Automapper;

public class CupboardClothesProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCupboardClothesRequest, CreateCupboardClothes>();
            CreateMap<UpdateCupboardClothesRequest, UpdateCupboardClothes>();
            CreateMap<DeleteCupboardClothesRequest, DeleteCupboardClothes>();

            CreateMap<GetCupboardClothesOutput, UpdateCupboardClothes>();

            CreateMap<GetCupboardClothesOutput, GetCupboardClothesResponse>();
        }
    }
}