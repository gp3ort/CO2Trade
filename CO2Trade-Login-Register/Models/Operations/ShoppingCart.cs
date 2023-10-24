using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.EntitiesUser;
using CO2Trade_Login_Register.Models.Projects;

namespace CO2Trade_Login_Register.Models.Operations;

public class ShoppingCart
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("Project")]
    public int IdProject { get; set; }
    public Project? Project { get; set; }
    public bool Processed { get; set; } = false;
    public bool Canceled { get; set; } = false;
    [ForeignKey("EntityUser")]
    public string IdEntityUser { get; set; }
    public EntityUser? EntityUser { get; set; }
}