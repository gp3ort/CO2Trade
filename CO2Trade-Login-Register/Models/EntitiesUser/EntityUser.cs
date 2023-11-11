using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.Projects;
using Microsoft.AspNetCore.Identity;

namespace CO2Trade_Login_Register.Models.EntitiesUser;

public class EntityUser : IdentityUser<int>
{
    public string BusinessName { get; set; }
    public string Address { get; set; }
    [ForeignKey("Rol")] 
    public int IdRol { get; set; }
    public Rol Rol { get; set; }
    [ForeignKey("EntityType")] 
    public int IdEntityType { get; set; }
    public EntityType? EntityType { get; set; }
    public string Description { get; set; }
    public override string PhoneNumber
    {
        get => base.PhoneNumber;
        set => base.PhoneNumber = value;
    }
    public override string UserName
    {
        get => base.UserName;
        set => base.UserName = value;
    }
    public decimal CO2Measure { get; set; } = 0;
}