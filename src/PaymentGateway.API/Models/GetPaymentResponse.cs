using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public class GetPaymentResponse
{
    [Required] public Guid PaymentId { get; set; }
    [Required] public string? Status { get; set; }
    [Required] public decimal Amount { get; set; }
    [Required] public string? Currency { get; set; }
    [Required] public CreditCardReadDto? CreditCard { get; set; }
}