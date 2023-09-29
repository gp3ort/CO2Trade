using System.Net;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/UsersAuth")]
[ApiController]
public class EntityUsersController : ControllerBase
{
    private readonly EntityUsersService _entityUsersService;
    public EntityUsersController( EntityUsersService entityUsersService)
    {
        _entityUsersService = entityUsersService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
    {
        APIResponse response = _entityUsersService.LoginUser(model).Result;
        return response.IsSuccess ? Ok(response) : BadRequest(response.Result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
    {
        APIResponse response = _entityUsersService.Register(model).Result;
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}