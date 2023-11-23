namespace CO2Trade_Login_Register.DTO.RequestDTO;

public class ProjectUpdateRequestDto
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    public decimal TonsOfOxygen { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ImageRequestDTO Image { get; set; }
    public int IdProjectType { get; set; }
}