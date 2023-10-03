using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/Project")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private APIResponse _response;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
        _response = new();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProject([FromBody] ProjectRequestDTO projectRequestDto)
    {
        _response = await _projectService.CreateNewProject(projectRequestDto);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }

    [HttpGet("getAllProjects")]
    public async Task<IActionResult> GetAllProjects()
    {
        _response = await _projectService.GetAllProjects();
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
}