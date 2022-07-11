using System.ComponentModel.DataAnnotations;
using MediatR;
using PaymentGateway.API.Models;

namespace PaymentGateway.API.Commands.ProcessPayment;

public class ProcessPaymentCommand : IRequest<ProcessPaymentResult>
{
    [Required]
    [Range(0.0, double.MaxValue)]
    public decimal Amount { get; set; }

    /// <summary>
    /// The currency the amount is in. Currently only GBP, EUR and USD are supported.
    /// </summary>
    /// <example>["GBP", "EUR", "USD"]</example>
    [Required]
    public string Currency { get; set; }

    [Required] public CreditCardWriteDto CreditCard { get; set; }
}