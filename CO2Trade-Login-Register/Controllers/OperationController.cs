using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[Route("api/MercadoPago")]
[ApiController]
public class OperationController
{
    private readonly IOperationService _operationService;
    private APIResponse _response;

    public OperationController(IOperationService operationService)
    {
        _operationService = operationService;
        _response = new();
    }
    
    
    
}