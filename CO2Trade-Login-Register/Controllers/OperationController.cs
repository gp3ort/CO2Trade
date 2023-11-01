using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/Operations")]
[ApiController]
public class OperationController : ControllerBase
{
    private readonly IOperationService _operationService;
    private APIResponse _response;

    public OperationController(IOperationService operationService)
    {
        _operationService = operationService;
        _response = new();
    }
    
    [HttpPost ("addToCart")]
    public async Task<IActionResult> AddToCart([FromBody] ShoppingCartRequestDTO shoppingCartRequest)
    {
        _response = await _operationService.AddToCart(shoppingCartRequest);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
    
    [HttpPost ("cancelCart")]
    public async Task<IActionResult> CancelCart([FromBody] ShoppingCartRequestDTO shoppingCartRequest)
    {
        _response = await _operationService.CancelCart(shoppingCartRequest);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
    
    [HttpPost ("processCart")]
    public async Task<IActionResult> ProcessCart([FromBody] ShoppingCartRequestDTO shoppingCartRequest)
    {
        _response = await _operationService.ProcessCart(shoppingCartRequest);
        return _response.IsSuccess ? Ok(_response) : BadRequest(_response);
    }
}