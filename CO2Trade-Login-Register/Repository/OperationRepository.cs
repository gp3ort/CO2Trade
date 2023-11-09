using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Models.Projects;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class OperationRepository : Repository<ShoppingCart>, IOperationRepository
{
    
    private readonly ApplicationDbContext _db;

    public OperationRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public async void CreateOperationProject(int cartId, int projectId, string entityUserId)
    {
        await _db.OperationProjects.AddAsync(new OperationProject()
        {
            IdShoppingCart = cartId,
            IdProject = projectId,
            IdEntityUser = entityUserId,
        });
    }
}