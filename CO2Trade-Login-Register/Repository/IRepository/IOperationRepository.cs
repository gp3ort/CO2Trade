using CO2Trade_Login_Register.Models.Operations;

namespace CO2Trade_Login_Register.Repository.IRepository;

public interface IOperationRepository : IRepository<ShoppingCart>
{
     void CreateOperationProject(int cartId, int projectId, int entityUserId);
}