using AutoMapper;
using BLL.Models.Input.CupboardModelnput;
using BLL.Models.Output.CupboardModelOutput;
using core_web_api.Models.Request.CupboardModelRequest;
using core_web_api.Models.Response.CupboardModelResponse;

namespace core_web_api.Automapper;

public class CupboardModelProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCupboardModelRequest, CreateCupboardModel>();
            CreateMap<UpdateCupboardModelRequest, UpdateCupboardModel>();
            CreateMap<DeleteCupboardModelRequest, DeleteCupboardModel>();
            CreateMap<GetCupboardModelOutput, GetCupboardModelResponse>();
        }
    }
}