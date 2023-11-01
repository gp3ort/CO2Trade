using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.DTO;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CO2Trade_Login_Register.Repository;

public class EntityUserRepository : Repository<EntityUser>, IEntityUserRepository
{
    
    private readonly ApplicationDbContext _db;
    private readonly UserManager<EntityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private string secretKey;
    private readonly IMapper _mapper;

    public EntityUserRepository(ApplicationDbContext db, UserManager<EntityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper) : base(db)
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
        var entityUser = _db.EntityUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.BusinessName.ToLower());
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
        int idEntityType = GetEntityType(registrationRequestDTO.EntityType);
        int rolId = GetRol(registrationRequestDTO.IdRol);
        EntityUser user = new()
        {
            UserName = registrationRequestDTO.BusinessName,
            Email = registrationRequestDTO.Email,
            IdEntityType = idEntityType,
            EntityType = await _db.EntityTypes.FirstOrDefaultAsync(e => e.Id == idEntityType),
            BusinessName = registrationRequestDTO.BusinessName,
            NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
            PhoneNumber = registrationRequestDTO.PhoneNumber,
            Description = registrationRequestDTO.Description,
            Address = registrationRequestDTO.Address,
            IdRol = rolId,
            Rol = await _db.Roles.FirstOrDefaultAsync(r => r.Id == rolId)
        };

        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
            
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync(user.Rol.Name).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(user.Rol.Name));
                }

                await _userManager.AddToRoleAsync(user, user.Rol.Name);
                var userToReturn =
                    _db.EntityUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.BusinessName);
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

    private int GetRol(int id)
    {
        switch (id)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
            default:
                return 2;
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