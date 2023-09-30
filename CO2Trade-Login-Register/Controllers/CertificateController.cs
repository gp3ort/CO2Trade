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

    private readonly ICertificateService CertificateService;

    public CertificateController(ICertificateService certificateService)
    {
        CertificateService = certificateService;
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
    
   
}