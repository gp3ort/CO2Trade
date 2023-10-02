using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.Operations;

public class Certificate
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Date { get; set; }
    public string ProjectName { get; set; }
    public decimal ProjectCO2 { get; set; }
    public string EntityName { get; set; }
    public string IdEntity { get; set; }
    public int IdProject { get; set; }
}