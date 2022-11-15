using AutoMapper;
using BLL.Models.Input.CupboardClothesInput;
using BLL.Models.Output.CupboardClothesOutput;
using DAL.Entities;
using DAL.Models;

namespace BLL.Automapper;

public class CupboardClothesProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeleteCupboardClothes, CupboardClothes>();
            CreateMap<CreateCupboardClothes, CupboardClothes>();
            CreateMap<UpdateCupboardClothes, CupboardClothes>();

            CreateMap<ProcedureOutput, Models.Output.ProcedureOutput.ProcedureOutput>();

            CreateMap<CupboardClothes, GetCupboardClothesOutput>();

            CreateMap<GetCupboardClothesOutput, UpdateCupboardClothes>();
        }
    }
}