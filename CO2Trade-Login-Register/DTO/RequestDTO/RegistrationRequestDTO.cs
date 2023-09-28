namespace CO2Trade_Login_Register.DTO.RequestDTO;

public class RegistrationRequestDTO
{
    public string BusinessName { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int EntityType { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public int IdRol { get; set; }
}