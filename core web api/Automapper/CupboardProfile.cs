using AutoMapper;
using BLL.Models.Input.CupboardInput;
using BLL.Models.Output.CupboardOutput;
using core_web_api.Models.Request.CupboardRequest;
using core_web_api.Models.Response.CupboardResponse;

namespace core_web_api.Automapper;

public class CupboardProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCupboardRequest, CreateCupboard>();
            CreateMap<DeleteCupboardRequest, DeleteCupboard>();
            CreateMap<UpdateCupboardRequest, UpdateCupboard>();

            CreateMap<GetCupboardResponse, GetCupboardOutput>();

            CreateMap<CupboardModelForGetCupboardOutput, CupboardModelForGetCupboardResponse>();

            CreateMap<GetCupboardOutput, DeleteCupboard>();

            CreateMap<GetCupboardOutput, GetCupboardResponse>();

            CreateMap<GetCupboardResponse, GetCupboardOutput>();
        }
    }
}