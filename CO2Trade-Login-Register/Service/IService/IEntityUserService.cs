using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;

namespace CO2Trade_Login_Register.Service.IService;

public interface IEntityUserService
{
    Task<APIResponse> LoginUser(LoginRequestDTO model);
    Task<APIResponse> Register(RegistrationRequestDTO model);
}