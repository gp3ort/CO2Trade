namespace CO2Trade_Login_Register.DTO.ResponseDTO;

public class MeasureResponseDTO
{
    public EntityUserDTO EntityUserDto { get; set; }
    public decimal CO2Measure { get; set; }
    public DateTime ExpirationDate { get; set; }
}