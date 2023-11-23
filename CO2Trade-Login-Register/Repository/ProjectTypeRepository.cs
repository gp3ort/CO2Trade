using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class ProjectTypeRepository : Repository<ProjectType>, IProjectTypesRepository
{
    public ProjectTypeRepository(ApplicationDbContext db) : base(db)
    {
    }
}