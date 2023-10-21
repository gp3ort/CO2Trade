using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.Operations;

namespace CO2Trade_Login_Register.Repository.IRepository;

public interface IOperationRepository : IRepository<ShoppingCart>
{
    Task<ShoppingCartResponseDTO> AddCart(ShoppingCartRequestDTO shoppingCartRequest);

}