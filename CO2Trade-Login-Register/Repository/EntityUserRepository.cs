using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.DTO;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Enum;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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

    public bool IsUniqueEntityUser(string username)
    {
        var entityUser = _db.EntityUsers.FirstOrDefault(x => x.UserName == username);
        if(entityUser == null)
        {
            return true;
        }
        return false;
    }

    public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
    {
        var entityUser = _db.EntityUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
        bool isValid = await _userManager.CheckPasswordAsync(entityUser, loginRequestDTO.Password);
        if (entityUser == null || isValid == false)
        {
            return new LoginResponseDTO()
            {
                Token = "",
                EntityUser = null
            };
        }

        var roles = await _userManager.GetRolesAsync(entityUser);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, entityUser.Id.ToString()),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        LoginResponseDTO loginResponseDto = new LoginResponseDTO()
        {
            Token = tokenHandler.WriteToken(token),
            EntityUser = _mapper.Map<EntityUserDTO>(entityUser),
            Role = roles.FirstOrDefault()
        };

        return loginResponseDto;
    }

    public async Task<RegistrationResponseDTO> Register(RegistrationRequestDTO registrationRequestDTO)
    {
        EntityUser user = new()
        {
            UserName = registrationRequestDTO.UserName,
            Email = registrationRequestDTO.UserName,
            IdEntityType = GetEntityType(registrationRequestDTO.EntityType),
            BusinessName = registrationRequestDTO.Name,
            NormalizedEmail = registrationRequestDTO.UserName.ToUpper(),
            PhoneNumber = registrationRequestDTO.PhoneNumber,
            Description = registrationRequestDTO.Description,
            Address = registrationRequestDTO.Address,
            IdRol = registrationRequestDTO.IdRol,
        };

        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
            
            if (result.Succeeded)
            {
                Roles rol = GetRol(registrationRequestDTO.IdRol);
                if (!_roleManager.RoleExistsAsync(rol.ToString()).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(rol.ToString()));
                }
                await _userManager.AddToRoleAsync(user, rol.ToString());
                var userToReturn =
                    _db.EntityUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
                RegistrationResponseDTO responseDto = new RegistrationResponseDTO
                {
                    EntityUser = _mapper.Map<EntityUserDTO>(userToReturn)
                };
                return responseDto;
            }
        }
        catch (Exception e)
        {
            
        }

        return new RegistrationResponseDTO();
    }

    private Roles GetRol(int id)
    {
        switch (id)
        {
            case 1:
                return Roles.ADMIN;
            case 2:
                return Roles.INDIVIDUAL_CUSTOMER;
            case 3:
                return Roles.ORGANIZATION;
            default:
                return Roles.INDIVIDUAL_CUSTOMER;
        }
    }

    private int GetEntityType(int id)
    {
        switch (id)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            default:
                return 1;
        }
    }
}