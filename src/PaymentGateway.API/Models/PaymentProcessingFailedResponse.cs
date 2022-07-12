using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public record PaymentProcessingFailedResponse
{
    /// <summary>
    /// A message describing the error
    /// </summary>
    /// <example>The provided credit card number is malformed, expected 16 digits.</example>
    [Required]
    public string? Message { get; }

    public PaymentProcessingFailedResponse(string? message)
    {
        Message = message;
    }
}