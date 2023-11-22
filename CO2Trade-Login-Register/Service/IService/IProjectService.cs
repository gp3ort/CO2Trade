using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;

namespace CO2Trade_Login_Register.Service.IService;

public interface IProjectService
{
      Task<APIResponse> CreateNewProject(ProjectRequestDTO projectRequestDto);
      Task<APIResponse> GetAllProjects();
      Task<APIResponse> GetProject(int id);
      Task<APIResponse> RemoveProject(int id);
      Task<APIResponse> UpdateProject(ProjectRequestDTO projectRequestDto);
      Task<APIResponse> GetAllAvailableProjects();
      Task<APIResponse> FilterProjects(FilterRequestDto filterRequestDto);
}