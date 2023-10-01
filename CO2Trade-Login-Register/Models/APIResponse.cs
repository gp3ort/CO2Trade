using System.Net;
using CO2Trade_Login_Register.DTO.ResponseDTO;

namespace CO2Trade_Login_Register.Models;

public class APIResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; } = true;
    public List<string> ErrorMessage { get; set; }
    public Object Result { get; set; }
    
    public APIResponse()
    {
        ErrorMessage = new List<string>();
    }
}