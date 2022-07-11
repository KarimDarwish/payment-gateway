using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

public class CreditCardDto
{
    [Required] public string CardNumber { get; set; }
    [Required] public int ExpiryMonth { get; set; }
    [Required] public int ExpiryTwoDigitYear { get; set; }
    [Required] public int Cvv { get; set; }
}