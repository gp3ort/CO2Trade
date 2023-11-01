using CO2Trade_Login_Register.DTO.MercadoPagoDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/MercadoPago")]
[ApiController]
public class MercadoPagoController : ControllerBase
{
    private readonly IMercadoPagoService _mercadoPagoService;
    private APIResponse _response;

    public MercadoPagoController(IMercadoPagoService mercadoPagoService)
    {
        _mercadoPagoService = mercadoPagoService;
        _response = new APIResponse();
    }

    [HttpPost ("pay")]
    public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDTO projectRequestDto)
    {
        _response = await _mercadoPagoService.ProcessPayment(projectRequestDto);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
}