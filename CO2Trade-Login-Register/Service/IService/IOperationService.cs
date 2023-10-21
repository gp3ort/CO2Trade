using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;

namespace CO2Trade_Login_Register.Service.IService;

public interface IOperationService
{
    Task<APIResponse> AddToCart(ShoppingCartRequestDTO shoppingCartRequest);
   
}