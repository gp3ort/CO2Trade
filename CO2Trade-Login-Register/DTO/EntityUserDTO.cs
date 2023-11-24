using CO2Trade_Login_Register.Models.EntitiesUser;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.DTO;

public class EntityUserDTO
{
    public string ID { get; set; }
    public string UserName { get; set; }
    public string BusinessName { get; set; }
    public string Address { get; set; }
    public string Rol { get; set; }
    public string EntityType { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public decimal CO2Measure { get; set; }
}