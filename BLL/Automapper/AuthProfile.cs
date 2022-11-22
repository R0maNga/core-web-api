using AutoMapper;
using BLL.Models.Output.AuthOutput;
using DAL.Entities;

namespace BLL.Automapper;

public class AuthProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserOutput, AppUser>();
            CreateMap<AppUser, UserOutput>();
        }
    }
}