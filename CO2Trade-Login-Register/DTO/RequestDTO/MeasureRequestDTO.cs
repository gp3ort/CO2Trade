namespace CO2Trade_Login_Register.DTO.RequestDTO;

public class MeasureRequestDTO
{
    public string EntityUserId { get; set; }
    public float CO2Measure { get; set; }
    public DateOnly ExpirationDate { get; set; }
}