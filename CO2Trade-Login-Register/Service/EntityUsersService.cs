using System.Net;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service.IService;

namespace CO2Trade_Login_Register.Service;

public class EntityUsersService : IEntityUserService
{
    private readonly IEntityUserRepository _entityUserRepo;
    private APIResponse _response;

    public EntityUsersService(IEntityUserRepository entityUserRepo)
    {
        _entityUserRepo = entityUserRepo;
        _response = new();
    }

    public async Task<APIResponse> LoginUser(LoginRequestDTO model)
    {
        var loginResponse = await _entityUserRepo.Login(model);
        if (loginResponse.EntityUser == null || string.IsNullOrEmpty(loginResponse.Token))
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessage.Add("Username or password is incorrect");
            return _response;
        }
        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        _response.Result = loginResponse;
        return _response;
    }
    
    public async Task<APIResponse> Register(RegistrationRequestDTO model)
    {
        bool ifUserNameUnique = _entityUserRepo.IsUniqueEntityUser(model.BusinessName);
        if (!ifUserNameUnique)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessage.Add("Username already exists");
            return _response;
        }

        var user = await _entityUserRepo.Register(model);
        if (user == null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessage.Add("Error while registering");
            return _response;
        }
        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        _response.Result = user;
        return _response;
    }

    public async Task<APIResponse> AddCO2(MeasureRequestDTO measureRequestDto)
    {
        try
        {
            MeasureResponseDTO measureResponseDto = await _entityUserRepo.AddCO2(measureRequestDto);
            if (measureResponseDto == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Error - user don't exist.");
                return _response;
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = measureResponseDto;
            return _response;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add(e.Message);
            return _response;
        }
        
    }

    public async Task<APIResponse> MyProjects(string idEntityUser)
    {
        try
        {
            List<ProjectResponseDTO> projectResponseDtos = await _entityUserRepo.MyProjects(idEntityUser);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = projectResponseDtos;
            return _response;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add(e.Message);
            return _response;
        }
    }
}