using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.Operations;

namespace CO2Trade_Login_Register.Models.Project;

public class OperationProject
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    [ForeignKey("Operation")]
    public int IdOperation { get; set; }
    public Operation? Operation { get; set; }
    [ForeignKey("IdProject")]
    public int IdProject { get; set; }
    public Project? Project { get; set; }
}