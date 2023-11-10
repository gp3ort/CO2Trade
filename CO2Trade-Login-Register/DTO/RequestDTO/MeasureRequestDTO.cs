namespace CO2Trade_Login_Register.DTO.RequestDTO;

public class MeasureRequestDTO
{
    public string EntityUserId { get; set; }
    public decimal CO2Measure { get; set; }
    public DateOnly ExpirationDate { get; set; }
}