using AutoMapper;
using CO2Trade_Login_Register.DTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.EntitiesUser;


namespace CO2Trade_Login_Register
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EntityUser, EntityUserDTO>().ReverseMap();
            CreateMap<EntityUser, RegistrationResponseDTO>().ReverseMap();
        }
    }
}
