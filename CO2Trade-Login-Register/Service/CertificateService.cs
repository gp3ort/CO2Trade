using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service.IService;
using Microsoft.IdentityModel.Tokens;

namespace CO2Trade_Login_Register.Service;

public class CertificateService : ICertificateService
{

    private readonly ICertificateRepository _certificateRepository;

    public CertificateService(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }
    
    public Task<CertificateResponseDTO> GetCertificate(string idEntity)
    {
        throw new NotImplementedException();
    }

    public async Task<CertificateResponseDTO> BuildCertificate(string idEntity)
    {
        if (idEntity.IsNullOrEmpty())
        {
            CertificateResponseDTO responseDto = new CertificateResponseDTO();
            responseDto.IsSuccess = false;
            responseDto.ErrorMessage.Add("Invalid or empty EntityUser ID");
            return responseDto;
        }
        CertificateResponseDTO certificateResponse = await _certificateRepository.BuildCertificateFile(idEntity);
        return certificateResponse;
    }
}