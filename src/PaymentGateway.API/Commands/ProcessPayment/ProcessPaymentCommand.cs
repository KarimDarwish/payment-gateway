using System.ComponentModel.DataAnnotations;
using MediatR;
using PaymentGateway.API.Models;

namespace PaymentGateway.API.Commands.ProcessPayment;

public class ProcessPaymentCommand : IRequest<ProcessPaymentResult>
{
    [Required] public decimal Amount { get; set; }
    [Required] public string Currency { get; set; }
    [Required] public CreditCardDto CreditCard { get; set; }
}