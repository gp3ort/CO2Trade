using AutoMapper;
using CO2Trade_Login_Register.DTO;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Projects;


namespace CO2Trade_Login_Register
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EntityUser, EntityUserDTO>()
                .ForMember(dest => dest.EntityType, opt => opt.MapFrom(src => src.EntityType.Description))
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol.Description));
            CreateMap<EntityUser, RegistrationResponseDTO>().ReverseMap();
            
            CreateMap<Project, ProjectRequestDTO>().ReverseMap();
            CreateMap<Project, ProjectResponseDTO>().ReverseMap();
            
            CreateMap<Image, ImageRequestDTO>().ReverseMap();

            CreateMap<Project, ProjectResponseDTO>().ReverseMap();
            CreateMap<Project, ShoppingCartResponseDTO>().ReverseMap();
        }
    }
}
