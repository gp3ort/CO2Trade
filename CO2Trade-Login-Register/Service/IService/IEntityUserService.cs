using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;

namespace CO2Trade_Login_Register.Service.IService;

public interface IEntityUserService
{
    Task<APIResponse> LoginUser(LoginRequestDTO loginRequestDto);
    Task<APIResponse> Register(RegistrationRequestDTO registrationRequestDto);
    Task<APIResponse> AddCO2(MeasureRequestDTO measureRequestDto);
    Task<APIResponse> MyProjects(int idEntityUser);
}