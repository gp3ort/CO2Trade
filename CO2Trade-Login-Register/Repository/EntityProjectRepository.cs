using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class EntityProjectRepository : Repository<EntityProject>, IEntityProjectRepository
{
    public EntityProjectRepository(ApplicationDbContext db) : base(db)
    {
    }
}