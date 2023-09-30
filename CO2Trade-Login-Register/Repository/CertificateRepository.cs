using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Repository.IRepository;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace CO2Trade_Login_Register.Repository;

public class CertificateRepository : ICertificateRepository
{
    private readonly ApplicationDbContext _db;
    private CertificateResponseDTO _responseDto;

    public CertificateRepository(ApplicationDbContext db)
    {
        _db = db;
        _responseDto = new CertificateResponseDTO();
    }

    public async Task<CertificateResponseDTO> BuildCertificateFile(string idEntity)
    {
        try
        {
            var entity = await _db.EntityUsers.FindAsync(idEntity);
            var document = new PdfDocument();
            string htmlDocument = "<h1>Certificate for :" + entity.BusinessName + "</h1>";
            PdfGenerator.AddPdfPages(document, htmlDocument, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string fileName = "Certificate for: " + entity.BusinessName + ".pdf";
            _responseDto.Bytes = response;
            _responseDto.ContentType = "application/pdf";
            _responseDto.FileName = fileName;
            return _responseDto;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage.Add(e.Message);
            return _responseDto;
        }
        
    }
}