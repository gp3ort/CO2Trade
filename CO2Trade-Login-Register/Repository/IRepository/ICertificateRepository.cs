using CO2Trade_Login_Register.DTO.ResponseDTO;

namespace CO2Trade_Login_Register.Repository.IRepository;

public interface ICertificateRepository
{
    Task<CertificateResponseDTO> BuildCertificateFile(string idEntity);
}