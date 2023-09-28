using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.GeneralSettings;

namespace CO2Trade_Login_Register.Models.Project;

public class Project
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal TonsOfOxygen { get; set; }
    public decimal price { get; set; }
    [ForeignKey("ProjectType")]
    public int IdProjectType { get; set; }
    public ProjectType ProjectType { get; set; }
    public string Description { get; set; }
    [ForeignKey("Image")]
    public int IdImage { get; set; }
    public Image Image { get; set; }
    
}