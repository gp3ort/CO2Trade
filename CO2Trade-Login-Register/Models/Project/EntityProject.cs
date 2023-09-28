using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.EntitiesUser;

namespace CO2Trade_Login_Register.Models.Project;

public class EntityProject
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    [ForeignKey("Project")]
    public int IdProject { get; set; }
    public Project Project { get; set; }
    [ForeignKey("EntityUser")]
    public string IdEntityUser { get; set; }
    public EntityUser EntityUser { get; set; }
}