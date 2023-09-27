using MagicVilla_VillaAPI.Dto;
using MagicVilla_VillaAPI.Dto.RequestDTO;
using MagicVilla_VillaAPI.Dto.ResponseDTO;

namespace CO2Trade_Login_Register.Repository;

public interface IEntityUserRepository
{
    bool IsUniqueEntityUser(string username);
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
    Task<EntityUserDTO> Register(RegistrationRequestDTO registerationRequestDTO);
}