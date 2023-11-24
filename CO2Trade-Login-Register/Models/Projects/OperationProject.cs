using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.Projects;

public class OperationProject
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("Project")]
    public int IdProject { get; set; }
    [ForeignKey("EntityUser")]
    public string IdEntityUser { get; set; }
    [ForeignKey("ShoppingCart")]
    public int IdShoppingCart { get; set; }
}