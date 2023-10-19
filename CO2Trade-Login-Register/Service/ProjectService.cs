using System.Net;
using AutoMapper;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service.IService;

namespace CO2Trade_Login_Register.Service;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private APIResponse _response;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _response = new();
        _mapper = mapper;
    }

    public async Task<APIResponse> CreateNewProject(ProjectRequestDTO projectRequestDto)
    {
        try
        {
            Project project = _mapper.Map<Project>(projectRequestDto);
            await _projectRepository.CreateAsync(project);
            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            _response.Result = _mapper.Map<ProjectResponseDTO>(project);
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

    public async Task<APIResponse> GetAllProjects()
    {
        try
        {
            List<Project> projects = await _projectRepository.GetAllAsync();
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = _mapper.Map<List<ProjectResponseDTO>>(projects);
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

    public async Task<APIResponse> GetProject(int id)
    {
        try
        {
            Project project = await _projectRepository.GetAsync(x => x.Id == id);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = _mapper.Map<ProjectResponseDTO>(project);
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

    public async Task<APIResponse> RemoveProject(int id)
    {
        try
        {
            Project project = await _projectRepository.GetAsync(x => x.Id == id);
            await _projectRepository.RemoveAsync(project);
            _response.Result = _mapper.Map<ProjectResponseDTO>(project);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;

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

    public async Task<APIResponse> UpdateProject(ProjectRequestDTO projectRequestDto)
    {
        try
        {
            Project project = _mapper.Map<Project>(projectRequestDto);
            await _projectRepository.Update(project);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = _mapper.Map<ProjectResponseDTO>(project);

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