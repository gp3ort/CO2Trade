using CO2Trade_Login_Register.DTO.MercadoPagoDTO;
using CO2Trade_Login_Register.Models;

namespace CO2Trade_Login_Register.Service.IService;

public interface IMercadoPagoService
{
    Task<APIResponse> ProcessPayment(PaymentRequestDTO paymentRequestDto);
}