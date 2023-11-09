using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Repository.IRepository;

namespace CO2Trade_Login_Register.Repository;

public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(ApplicationDbContext db) : base(db)
    {
    }
}