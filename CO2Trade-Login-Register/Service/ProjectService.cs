using System.Net;
using AutoMapper;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service.IService;

namespace CO2Trade_Login_Register.Service;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IProjectTypesRepository _projectTypesRepository;
    private APIResponse _response;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IImageRepository imageRepository, IProjectTypesRepository projectTypesRepository ,IMapper mapper)
    {
        _projectRepository = projectRepository;
        _imageRepository = imageRepository;
        _projectTypesRepository = projectTypesRepository;
        _response = new();
        _mapper = mapper;
    }

    public async Task<APIResponse> CreateNewProject(ProjectRequestDTO projectRequestDto)
    {
        try
        {
            Project project = _mapper.Map<Project>(projectRequestDto);
            await _imageRepository.CreateAsync(project.Image);
            await _projectRepository.CreateAsync(project);
            project.ProjectType = await _projectTypesRepository.GetAsync(x => x.Id == projectRequestDto.IdProjectType);
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
            List<Project> projects = await _projectRepository.GetAllProjectsAsync();
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

    public async Task<APIResponse> GetAllAvailableProjects()
    {
        try
        {
            List<Project> projects = await _projectRepository.GetAllAvailableProjects();
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

    public async Task<APIResponse> FilterProjects(FilterRequestDto filterRequestDto)
    {
        try
        {
            List<Project> projects = await _projectRepository.GetFilterProject(filterRequestDto);
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
            Project project = await _projectRepository.GetAsync(id);
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

    public async Task<APIResponse> UpdateProject(ProjectUpdateRequestDto projectUpdateRequestDto)
    {
        try
        {
            Project projectUpdate = await _projectRepository.GetAsync(x => x.Id == projectUpdateRequestDto.IdProject);
            projectUpdate.Name = projectUpdateRequestDto.Name;
            projectUpdate.TonsOfOxygen = projectUpdateRequestDto.TonsOfOxygen;
            projectUpdate.Price = projectUpdateRequestDto.Price;
            projectUpdate.Description = projectUpdateRequestDto.Description;
            projectUpdate.Image = _mapper.Map<Image>(projectUpdate.Image);
            projectUpdate.IdProjectType = projectUpdateRequestDto.IdProjectType;
            
            await _projectRepository.Update(projectUpdate);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = _mapper.Map<ProjectResponseDTO>(projectUpdateRequestDto);

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