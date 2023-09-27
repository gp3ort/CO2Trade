using AutoMapper;
using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models;
using MagicVilla_VillaAPI.Dto;
using MagicVilla_VillaAPI.Dto.RequestDTO;
using MagicVilla_VillaAPI.Dto.ResponseDTO;
using Microsoft.AspNetCore.Identity;

namespace CO2Trade_Login_Register.Repository;

public class EntityUserRepository : IEntityUserRepository
{
    
    private readonly ApplicationDbContext _db;
    private readonly UserManager<EntityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private string secretKey;
    private readonly IMapper _mapper;

    public EntityUserRepository(ApplicationDbContext db, UserManager<EntityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
        secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        _mapper = mapper;
    }

    public bool IsUniqueUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
    {
        throw new NotImplementedException();
    }

    public Task<EntityUserDTO> Register(RegistrationRequestDTO registerationRequestDTO)
    {
        throw new NotImplementedException();
    }
}