using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models.Projects;

namespace CO2Trade_Login_Register.Repository.IRepository;

public interface IProjectRepository : IRepository<Project>
{ 
    Task<List<Project>> GetAllAvailableProjects();
    Task<List<Project>> GetAllProjectsAsync();
    Task<List<Project>> GetFilterProject(FilterRequestDto filterRequestDto);
    Task<Project> GetAsync(int id);
}