using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.Projects;

public class OperationProject
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("IdProject")]
    public int IdProject { get; set; }
    [ForeignKey("IdEntityUser")]
    public string IdEntityUser { get; set; }
    [ForeignKey("IdShoppingCart")]
    public int IdShoppingCart { get; set; }
}