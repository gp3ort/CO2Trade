using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.EntitiesUser;

namespace CO2Trade_Login_Register.Models.Projects;

public class EntityProject
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("Project")]
    public int IdProject { get; set; }
    public Project? Project { get; set; }
    [ForeignKey("EntityUser")]
    public int IdEntityUser { get; set; }
    public EntityUser? EntityUser { get; set; }
}