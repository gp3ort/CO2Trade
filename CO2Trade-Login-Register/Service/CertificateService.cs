using CO2Trade_Login_Register.DTO.RequestDTO;
using CO2Trade_Login_Register.DTO.ResponseDTO;
using CO2Trade_Login_Register.Repository.IRepository;
using CO2Trade_Login_Register.Service.IService;

namespace CO2Trade_Login_Register.Service;

public class CertificateService : ICertificateService
{

    private readonly ICertificateRepository _certificateRepository;

    public CertificateService(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }
    
    public async Task<CertificateResponseDTO> GetCertificate(CertificateRequestDTO certificateRequest)
    {
        if (certificateRequest == null)
        {
            CertificateResponseDTO responseDto = new CertificateResponseDTO();
            responseDto.IsSuccess = false;
            responseDto.ErrorMessage.Add("Invalid or empty EntityUser ID");
            return responseDto;
        }
        CertificateResponseDTO certificateResponse = await _certificateRepository.GetCertificateFile(certificateRequest);
        return certificateResponse;
    }

    public async Task<CertificateResponseDTO> BuildCertificate(CertificateRequestDTO certificateRequest)
    {
        if (certificateRequest == null)
        {
            CertificateResponseDTO responseDto = new CertificateResponseDTO();
            responseDto.IsSuccess = false;
            responseDto.ErrorMessage.Add("Invalid or empty EntityUser ID");
            return responseDto;
        }
        CertificateResponseDTO certificateResponse = await _certificateRepository.BuildCertificateFile(certificateRequest);
        return certificateResponse;
    }
}