using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.EntitiesUser;

namespace CO2Trade_Login_Register.Models.Measure;

public class MeasureCO2
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("EntityUser")]
    public int IdEntidad { get; set; }
    public EntityUser? EntityUser { get; set; }
    public DateTime DateTime { get; set; }
    public decimal CO2Measure { get; set; }
    public string BusinessName { get; set; }
    public DateTime ExpirationDate { get; set; }
}