using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CO2Trade_Login_Register.Models.Operations;

namespace CO2Trade_Login_Register.Models.Billing;

public class Bill
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id{ get; set; }
    public DateTime OperationDate { get; set; }
    [ForeignKey("Operation")]
    public int IdOperacion { get; set; }
    public Operation Operation { get; set; }
    public decimal GrossTotal { get; set; }
    public decimal NetTotal { get; set; }
    [ForeignKey("TaxCondition")]
    public int IdTaxCondition { get; set; }
    public TaxCondition TaxCondition { get; set; }
    [ForeignKey("TaxDocumentType")]
    public int IdTaxDocumentType { get; set; }
    public TaxDocumentType TaxDocumentType { get; set; }

}