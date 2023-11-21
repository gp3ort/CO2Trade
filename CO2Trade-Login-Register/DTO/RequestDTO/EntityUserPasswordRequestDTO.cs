namespace CO2Trade_Login_Register.DTO.RequestDTO;

public class EntityUserPasswordRequestDTO
{
    public string EntityUserId { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
}