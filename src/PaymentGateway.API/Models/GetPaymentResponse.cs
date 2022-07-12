using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public class GetPaymentResponse
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
    
    /// <summary>
    /// The total amount of the payment
    /// </summary>
    /// <example>9.90</example>
    [Required] public decimal Amount { get; set; }

    /// <summary>
    /// The currency used as part of the payment
    /// </summary>
    /// <example>GBP</example>
    [Required] public string? Currency { get; set; }
    [Required] public CreditCardReadDto? CreditCard { get; set; }
}