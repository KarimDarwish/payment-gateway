using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public class PaymentProcessedResponse
{
    /// <summary>
    /// A unique identifier for the payment
    /// </summary>
    /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
    [Required] public Guid PaymentId { get; set; }
    
    /// <summary>
    /// The status of the payment. Can be "Completed" or "Declined"
    /// </summary>
    /// <example>Completed</example>
    [Required] public string? Status { get; set; }
}