using AutoMapper;
using BLL.Models.Input.CupboardInput;
using BLL.Models.Output.CupboardOutput;
using DAL.Entities;

namespace BLL.Automapper;

public class CupboardProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeleteCupboard, Cupboard>();
            CreateMap<CreateCupboard, Cupboard>();
            CreateMap<UpdateCupboard, Cupboard>();

            CreateMap<Cupboard, GetCupboardOutput>();


            CreateMap<GetCupboardOutput, UpdateCupboard>();


            CreateMap<CupboardModel, CupboardModelForGetCupboardOutput>();
        }
    }
}