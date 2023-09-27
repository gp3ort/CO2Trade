using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CO2Trade_Login_Register.Models.EntitiesUser;

public class EntityUser : IdentityUser
{
    public string BusinessName { get; set; }
    public string Address { get; set; }
    [ForeignKey("Rol")] 
    public int IdRol { get; set; }
    public Rol? Rol { get; set; }
    [ForeignKey("EntityType")] 
    public int IdEntityType { get; set; }
    public EntityType? EntityType { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
}