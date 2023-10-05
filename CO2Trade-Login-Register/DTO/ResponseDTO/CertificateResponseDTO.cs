namespace CO2Trade_Login_Register.DTO.ResponseDTO;

public class CertificateResponseDTO
{
    public int id { get; set; }
    public byte[] Bytes { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public bool IsSuccess { get; set; } = true;
    public List<string> ErrorMessage { get; set; }
    
    public CertificateResponseDTO()
    {
        ErrorMessage = new List<string>();
    }

}