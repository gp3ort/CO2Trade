using CO2Trade_Login_Register.Models.GeneralSettings;
using CO2Trade_Login_Register.Models.Projects;

namespace CO2Trade_Login_Register.DTO.ResponseDTO;

public class ProjectResponseDTO
{
    public int id { get; set; }
    public string Name { get; set; }
    public decimal TonsOfOxygen { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Image? Image { get; set; }
    public int IdProjectType { get; set; }
    public ProjectType? ProjectType { get; set; }
    public bool sold { get; set; }
}