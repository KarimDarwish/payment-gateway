using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public class PaymentProcessedResponse
{
    [Required] public Guid PaymentId { get; set; }
}