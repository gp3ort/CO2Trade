using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/UsersAuth")]
[ApiController]
public class EntityUsersController : ControllerBase
{
    private readonly IEntityUserService _entityUsersService;
    private APIResponse _response;
    public EntityUsersController( IEntityUserService entityUsersService)
    {
        _entityUsersService = entityUsersService;
        _response = new();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        _response = _entityUsersService.LoginUser(model).Result;
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
    {
        _response = _entityUsersService.Register(model).Result;
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }

    [HttpPost("addCO2")]
    public async Task<IActionResult> AddMeasure([FromBody] MeasureRequestDTO measureRequestDto)
    {
        _response = await _entityUsersService.AddCO2(measureRequestDto);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
    
    [HttpPost("myProjects")]
    public async Task<IActionResult> MyProjects(string idEntityUser)
    {
        _response = await _entityUsersService.MyProjects(idEntityUser);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.Name);
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User session token not found. Please log in to access this resource.");
        }
        _response = await _entityUsersService.GetUser(userId);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
}