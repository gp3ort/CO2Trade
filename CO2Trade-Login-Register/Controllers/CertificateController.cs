using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace CO2Trade_Login_Register.Controllers;

[ApiController]
public class CertificateController : ControllerBase
{
    
    [HttpGet("certificate")]
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