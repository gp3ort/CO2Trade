using CO2Trade_Login_Register.Models.GeneralSettings;

namespace CO2Trade_Login_Register.DTO.RequestDTO;

public class ProjectRequestDTO
{
    public string Name { get; set; }
    public decimal TonsOfOxygen { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Image? Image { get; set; }
}