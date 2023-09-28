using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.EntitiesUser;

namespace CO2Trade_Login_Register.Models.Documents;

public class EntityDocument
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    [ForeignKey("EntityUser")]
    public string IdEntidad { get; set; }
    public EntityUser EntityUser { get; set; }
    [ForeignKey("Document")]
    public int IdDocument { get; set; }
    public Document Document { get; set; }
}