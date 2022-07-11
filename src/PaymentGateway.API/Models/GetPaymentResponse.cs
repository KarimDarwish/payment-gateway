using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public class GetPaymentResponse
{
    [Required] public Guid PaymentId { get; set; }
}