using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CO2Trade_Login_Register.Models.GeneralSettings;

public class Configuration
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string PlatformName { get; set; }
    public string Description { get; set; }
    public string Currency { get; set; }
    [ForeignKey("Image")]
    public int IdLogo { get; set; }
    public Image? Image { get; set; }
    public string Ip { get; set; }
    public int puerto { get; set; }
}