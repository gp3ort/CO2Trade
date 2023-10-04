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

public class EntityUserRepository : IEntityUserRepository
{
    
    private readonly ApplicationDbContext _db;
    private readonly UserManager<EntityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public EntityUserRepository(ApplicationDbContext db, UserManager<EntityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
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
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, entityUser.BusinessName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var userRole in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        string token = GenerateToken(authClaims);

        LoginResponseDTO loginResponseDto = new LoginResponseDTO()
        {
            Token = token,
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
                if (!_roleManager.RoleExistsAsync(UserRoles.Admin).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                await _userManager.AddToRoleAsync(user, UserRoles.Admin);

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


    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
        var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JWTKey:ValidIssuer"],
            Audience = _configuration["JWTKey:ValidAudience"],
            //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
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