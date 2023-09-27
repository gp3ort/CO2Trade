using MagicVilla_VillaAPI.Dto;
using MagicVilla_VillaAPI.Dto.RequestDTO;
using MagicVilla_VillaAPI.Dto.ResponseDTO;

namespace CO2Trade_Login_Register.Repository;

public class UserRepository : IUserRepository
{
    public bool IsUniqueUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
    {
        throw new NotImplementedException();
    }

    public Task<EntityDTO> Register(RegistrationRequestDTO registerationRequestDTO)
    {
        throw new NotImplementedException();
    }
}