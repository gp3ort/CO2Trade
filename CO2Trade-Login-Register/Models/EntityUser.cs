using Microsoft.AspNetCore.Identity;

namespace CO2Trade_Login_Register.Models;

public class EntityUser : IdentityUser
{
    public string BusinessName { get; set; }
    public string Address { get; set; }
    public int EntityType { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
}