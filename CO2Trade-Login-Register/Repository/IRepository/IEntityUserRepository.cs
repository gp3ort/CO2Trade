using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;

namespace CO2Trade_Login_Register.Repository.IRepository;

public interface IEntityUserRepository
{
    bool IsUniqueEntityUser(string username);
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    Task<RegistrationResponseDTO> Register(RegistrationRequestDTO registrationRequestDTO);
}