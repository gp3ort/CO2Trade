using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.EntitiesUser;

namespace CO2Trade_Login_Register.Models.Operations;

public class OperationCertificate
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    public DateTime OperationDate { get; set; }
    [ForeignKey("Certificate")]
    public int IdCertificate { get; set; }
    public Certificate? Certificate { get; set; }
    [ForeignKey("EntityUser")]
    public int IdEntityUser { get; set; }
    public EntityUser? EntityUser { get; set; }
    public decimal TotalCompensation { get; set; }
    
}