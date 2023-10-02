using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.Project;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    private readonly ApplicationDbContext _db;

    public ProjectRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    
}