using System.Net;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CO2Trade_Login_Register.Controllers;

[ApiController]
[Route("api/Certificate")]
public class CertificateController : ControllerBase
{

    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }
    
    [HttpGet("buildCertificate")]
    public async Task<IActionResult> BuildCertificate(string idEntity)
    {
        CertificateResponseDTO response =  _certificateService.BuildCertificate(idEntity).Result;
        return response.IsSuccess ? File(response.Bytes, response.ContentType, response.FileName) : BadRequest(BuildBadRequestApiResponse(response));
    }

    private APIResponse BuildBadRequestApiResponse(CertificateResponseDTO certificateResponseDto)
    {
        APIResponse response = new APIResponse();
        response.IsSuccess = false;
        response.ErrorMessage = certificateResponseDto.ErrorMessage;
        response.StatusCode = HttpStatusCode.BadRequest;
        return response;
    }
    
    
   
}