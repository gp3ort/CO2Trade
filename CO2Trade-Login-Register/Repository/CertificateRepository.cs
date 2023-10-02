using CO2Trade_Login_Register.Data;
using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Models.Operations;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Utils;
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

    public async Task<CertificateResponseDTO> BuildCertificateFile(CertificateRequestDTO certificateRequest)
    {
        try
        {
            string idEntity = certificateRequest.IdEntity;
            var entity = await _db.EntityUsers.FindAsync(idEntity);
            var project = await _db.Projects.FindAsync(certificateRequest.IdProject);
            string entityName = entity.BusinessName;
            string projectName = project.Name;
            decimal projectCO2 = project.TonsOfOxygen;
            DateTime actualDate = DateTime.Now;
            string date = actualDate.ToString("M/d/yyyy");

            var document = new PdfDocument();
            string htmlDocument = CertificateMaker.BuildCertificate(entityName, projectName, projectCO2, date);

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

            Certificate certificate = new Certificate
            {
                Id = 0,
                Date = date,
                ProjectName = projectName,
                ProjectCO2 = projectCO2,
                EntityName = entityName,
                IdEntity = idEntity,
                IdProject = project.Id,
            };

            await _db.Certificates.AddAsync(certificate);
            await _db.SaveChangesAsync();
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