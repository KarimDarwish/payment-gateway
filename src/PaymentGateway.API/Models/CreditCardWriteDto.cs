using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

[DisplayName("CreditCardWriteModel")]
public record CreditCardWriteDto
{
    /// <summary>
    /// The card number of the credit card
    /// </summary>
    /// <example>123 123 123 123 1234</example>
    [Required]
    public string CardNumber { get; set; }

    /// <summary>
    /// Month of expiry for the credit card (1-12)
    /// </summary>
    /// <example>12</example>
    [Required] [Range(1, 12)] public int ExpiryMonth { get; set; }
    
    /// <summary>
    /// Year of expiry for the credit card as two digit year
    /// </summary>
    /// <example>29</example>
    [Required] [Range(0, 99)] public int ExpiryTwoDigitYear { get; set; }
    
    /// <summary>
    /// The card verification value used to make the payment
    /// </summary>
    /// <example>123</example>
    [Required] public int Cvv { get; set; }

    public CreditCardWriteDto(string cardNumber, int expiryMonth, int expiryTwoDigitYear, int cvv)
    {
        CardNumber = cardNumber;
        ExpiryMonth = expiryMonth;
        ExpiryTwoDigitYear = expiryTwoDigitYear;
        Cvv = cvv;
    }
}