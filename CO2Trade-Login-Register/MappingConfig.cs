using AutoMapper;
using CO2Trade_Login_Register.Models.EntitiesUser;
using MagicVilla_VillaAPI.Dto;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EntityUser, EntityUserDTO>().ReverseMap();
        }
    }
}
