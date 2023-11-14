using CO2Trade_Login_Register.DTO.RequestDTO;

namespace CO2Trade_Login_Register.DTO.MercadoPagoDTO;

public class PaymentRequestDTO
{
    public string Token { get; set; }

    public string IssuerId { get; set; }
    
    public string PaymentMethodId { get; set; }
    
    public decimal TransactionAmount { get; set; }
    
    public int Installments { get; set; }
    
    public string ProductDescription { get; set; }
    
    public PayerDTO Payer { get; set; }
    public ShoppingCartRequestDTO ShoppingCartRequestDto { get; set; }
}