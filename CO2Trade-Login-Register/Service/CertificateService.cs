using CO2Trade_Login_Register.Models;
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
    
    public Task<APIResponse> getCertificate()
    {
        throw new NotImplementedException();
    }
}