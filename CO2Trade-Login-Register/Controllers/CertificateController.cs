using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

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

    [HttpGet("getCertificate")]
    public async Task<IActionResult> GetCertificate(String invoiceNumber)
    {
        var document = new PdfDocument();
        string htmlDocument = "<h1>Test</h1>";
        PdfGenerator.AddPdfPages(document, htmlDocument, PageSize.A4);
        byte[]? response = null;
        using (MemoryStream ms = new MemoryStream())
        {
            document.Save(ms);
            response = ms.ToArray();
        }

        string fileName = "Inovice_" + invoiceNumber + ".pdf";
        return File(response, "application/pdf", fileName);
    }
    
    [HttpGet("buildCertificate")]
    public async Task<IActionResult> BuildCertificate(string idEntity)
    {
        CertificateResponseDTO response =  _certificateService.BuildCertificate(idEntity).Result;
        return response.IsSuccess ?  File(response.Bytes, response.ContentType, response.FileName) : BadRequest();
    }
    
    
   
}