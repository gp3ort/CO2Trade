using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/Project")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService ProjectService;

    public ProjectController(IProjectService projectService)
    {
        ProjectService = projectService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProject()
    {
        return null;
    }
}