using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

[DisplayName("CreditCardReadModel")]
public record CreditCardReadDto
{
    [Required] public string CardNumber { get; set; }
    [Required] [Range(1, 12)] public int ExpiryMonth { get; set; }
    [Required] [Range(0, 99)] public int ExpiryTwoDigitYear { get; set; }

    public CreditCardReadDto(string cardNumber, int expiryMonth, int expiryTwoDigitYear)
    {
        CardNumber = cardNumber;
        ExpiryMonth = expiryMonth;
        ExpiryTwoDigitYear = expiryTwoDigitYear;
    }
}