using System.ComponentModel.DataAnnotations;
using MediatR;
using PaymentGateway.API.Models;

namespace PaymentGateway.API.Commands.ProcessPayment;

public class ProcessPaymentCommand : IRequest<ProcessPaymentResult>
{
    /// <summary>
    /// The payment amount of the product/subscription
    /// </summary>
    /// <example>9.90</example>
    [Required]
    [Range(0.0, double.MaxValue)]
    public decimal Amount { get; set; }

    /// <summary>
    /// The currency the amount is in. Currently only GBP, EUR and USD are supported.
    /// </summary>
    /// <example>GBP</example>
    [Required]
    public string Currency { get; set; }

    /// <summary>
    /// The credit card used to make the payment
    /// </summary>
    [Required] public CreditCardWriteDto CreditCard { get; set; }

    public ProcessPaymentCommand(decimal amount, string currency, CreditCardWriteDto creditCard)
    {
        Amount = amount;
        Currency = currency;
        CreditCard = creditCard;
    }
}