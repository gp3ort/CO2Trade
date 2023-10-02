using AutoMapper;
using CO2Trade_Login_Register.DTO;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Project;


namespace CO2Trade_Login_Register
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EntityUser, EntityUserDTO>().ReverseMap();
            CreateMap<EntityUser, RegistrationResponseDTO>().ReverseMap();
            
            CreateMap<Project, ProjectRequestDTO>().ReverseMap();
            CreateMap<Project, ProjectResponseDTO>().ReverseMap();
            
            CreateMap<Image, ImageRequestDTO>().ReverseMap();
        }
    }
}
