namespace MagicVilla_VillaAPI.Dto.RequestDTO;

public class RegistrationRequestDTO
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public int EntityType { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public int IdRol { get; set; }
}