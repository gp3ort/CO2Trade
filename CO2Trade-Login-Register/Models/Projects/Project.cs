using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.GeneralSettings;

namespace CO2Trade_Login_Register.Models.Projects;

public class Project
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal TonsOfOxygen { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    [ForeignKey("Image")]
    public int IdImage { get; set; }
    public Image? Image { get; set; }
    public bool Sold { get; set; } = false;
    [ForeignKey("ProjectType")]
    public int IdProjectType { get; set; }
    public ProjectType? ProjectType { get; set; }
}