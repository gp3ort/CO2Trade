using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.EntitiesUser;
using System.Security.Claims;

namespace CO2Trade_Login_Register.Repository.IRepository;

public interface IEntityUserRepository : IRepository<EntityUser>
{
    bool IsUniqueEntityUser(string username);
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    Task<RegistrationResponseDTO> Register(RegistrationRequestDTO registrationRequestDTO);
    Task<MeasureResponseDTO> AddCO2(MeasureRequestDTO measureRequestDto);
    Task<List<ProjectResponseDTO>> MyProjects(string idEntityUser);
    Task<EntityUser> GetUser(string userId);
}