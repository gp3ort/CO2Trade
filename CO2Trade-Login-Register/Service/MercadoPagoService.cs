using System.Net;
using CO2Trade_Login_Register.DTO.MercadoPagoDTO;
using CO2Trade_Login_Register.Models;
using CO2Trade_Login_Register.Service.IService;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;

namespace CO2Trade_Login_Register.Service;

public class MercadoPagoService : IMercadoPagoService
{
    private readonly string _mercadoPagoAccessToken;
    private PaymentClient _paymentClient;
    private APIResponse _response;

    public MercadoPagoService()
    {
        _mercadoPagoAccessToken = "TEST-6195431444930380-100413-4a06717435e2255470c353395d04ddc1-156763454";
        _paymentClient = new PaymentClient();
        _response = new();
    }

    public async Task<APIResponse> ProcessPayment(PaymentRequestDTO paymentRequestDto)
    {
        try
        {
            MercadoPagoConfig.AccessToken = _mercadoPagoAccessToken;
            Payment createdPayment = _paymentClient.Create(CreatePaymentRequest(paymentRequestDto));
            PaymentResponseDTO paymentResponseDto = new PaymentResponseDTO()
            {
                Id = createdPayment.Id,
                Status = createdPayment.Status,
                Detail = createdPayment.StatusDetail
            };
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = paymentResponseDto;

            return _response;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.ErrorMessage.Add(e.Message);
            return _response;
        }
    }

    private PaymentCreateRequest CreatePaymentRequest(PaymentRequestDTO paymentRequestDto)
    {
        PaymentCreateRequest paymentCreateRequest = new PaymentCreateRequest();
        paymentCreateRequest.TransactionAmount = paymentRequestDto.TransactionAmount;
        paymentCreateRequest.Token = paymentRequestDto.Token;
        paymentCreateRequest.Description = paymentRequestDto.ProductDescription;
        paymentCreateRequest.Installments = paymentRequestDto.Installments;
        paymentCreateRequest.PaymentMethodId = paymentRequestDto.PaymentMethodId;
        paymentCreateRequest.Payer = new PaymentPayerRequest()
        {
            Email = paymentRequestDto.Payer.email,
            Identification = new IdentificationRequest()
            {
                Type = paymentRequestDto.Payer.identification.type,
                Number = paymentRequestDto.Payer.identification.number
            }
        };
        return paymentCreateRequest;
    }
}