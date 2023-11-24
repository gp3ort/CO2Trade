using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CO2Trade_Login_Register.Repository;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    private readonly ApplicationDbContext _db;

    public ProjectRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Project> GetAsync(int id)
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType).Where(x => x.Id == id).FirstAsync();
    }
    
    public async Task<List<Project>> GetAllProjectsAsync()
    {
        List<Project> projects = await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .ToListAsync();

        return projects;
    }

    public async Task<List<Project>> GetAllAvailableProjects()
    {
        List<Project> projects = await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.Sold == false).ToListAsync();

        return projects;
    }

    public async Task<List<Project>> GetFilterProject(FilterRequestDto filterRequestDto)
    {
        switch (filterRequestDto.Filter)
        {
            case "sold":
                return await GetSoldProjects();
            case "availables":
                return await GetNoSoldProjects();
            case "1":
                return await GetForestryProjects();
            case "2":
                return await GetRenewableEnergiesProjects();
            case "3":
                return await GetCircularEconomiesProjects();
            case "4":
                return await GetAppliedScienceProjects();
            case "5":
                return await GetOthersProjects();
            default:
                return await GetAllProjectsAsync();
        }
    }

    private async Task<List<Project>> GetSoldProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.Sold == true).ToListAsync();
    }
    
    private async Task<List<Project>> GetNoSoldProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.Sold == false).ToListAsync();
    }
    
    private async Task<List<Project>> GetForestryProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.IdProjectType == 1).ToListAsync();
    }
    
    private async Task<List<Project>> GetRenewableEnergiesProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.IdProjectType == 2).ToListAsync();
    }
    
    private async Task<List<Project>> GetCircularEconomiesProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.IdProjectType == 3).ToListAsync();
    }
    
    private async Task<List<Project>> GetAppliedScienceProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.IdProjectType == 4).ToListAsync();
    }
    
    private async Task<List<Project>> GetOthersProjects()
    {
        return await _db.Projects.Include(i => i.Image).Include(t => t.ProjectType)
            .Where(x => x.IdProjectType == 5).ToListAsync();
    }
}