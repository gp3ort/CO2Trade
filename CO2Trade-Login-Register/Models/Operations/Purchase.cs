using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.Operations;

public class Purchase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id{ get; set; }
    [ForeignKey("EntityUser")]
    public string IdEntityUser { get; set; }
    [ForeignKey("ShoppingCart")]
    public int IdShoppingCart { get; set; }
    public decimal Total { get; set; }
    public DateTime DateTime { get; set; }
    public int OrderNumber { get; set; }
}