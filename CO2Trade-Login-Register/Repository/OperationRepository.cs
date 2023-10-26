using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class OperationRepository : Repository<ShoppingCart>, IOperationRepository
{
    
    private readonly ApplicationDbContext _db;

    public OperationRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
}