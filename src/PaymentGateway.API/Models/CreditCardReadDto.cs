using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

[DisplayName("CreditCardReadModel")]
public record CreditCardReadDto
{
    /// <summary>
    /// A masked representation of the credit card number
    /// </summary>
    /// <example>*** *** *** *** 1234</example>
    [Required]
    public string CardNumber { get; set; }

    /// <summary>
    /// Month of expiry for the credit card (1-12)
    /// </summary>
    /// <example>12</example>
    [Required]
    [Range(1, 12)]
    public int ExpiryMonth { get; set; }

    /// <summary>
    /// Year of expiry for the credit card as two digit year
    /// </summary>
    /// <example>29</example>
    [Required]
    [Range(0, 99)]
    public int ExpiryTwoDigitYear { get; set; }

    public CreditCardReadDto(string cardNumber, int expiryMonth, int expiryTwoDigitYear)
    {
        CardNumber = cardNumber;
        ExpiryMonth = expiryMonth;
        ExpiryTwoDigitYear = expiryTwoDigitYear;
    }
}