using AutoMapper;
using BLL.Models.Input.CupboardModelnput;
using BLL.Models.Output.CupboardModelOutput;
using DAL.Entities;

namespace BLL.Automapper;

public class CupboardModelProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeleteCupboardModel, CupboardModel>();
            CreateMap<CreateCupboardModel, CupboardModel>();
            CreateMap<UpdateCupboardModel, CupboardModel>();
            CreateMap<CupboardModel, GetCupboardModelOutput>();
        }
    }
}