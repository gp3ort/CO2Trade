using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.Operations;

public class Purchase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    [ForeignKey("EntityUser")]
    public int IdEntityUser { get; set; }
    [ForeignKey("ShoppingCart")]
    public int IdShoppingCart { get; set; }
    [ForeignKey("Project")]
    public int IdProject { get; set; }
    public decimal Total { get; set; }
    public DateTime DateTime { get; set; }
    public int OrderNumber { get; set; }
    public decimal Revenue { get; set; }
}