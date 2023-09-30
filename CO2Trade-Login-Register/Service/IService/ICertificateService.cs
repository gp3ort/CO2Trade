using CO2Trade_Login_Register.Models;

namespace CO2Trade_Login_Register.Service.IService;

public interface ICertificateService
{
    Task<APIResponse> getCertificate();
}