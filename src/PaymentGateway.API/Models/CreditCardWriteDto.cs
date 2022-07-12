﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.Models;

[DisplayName("CreditCardWriteModel")]
public record CreditCardWriteDto
{
    [Required] public string CardNumber { get; set; }
    [Required] [Range(1, 12)] public int ExpiryMonth { get; set; }
    [Required] [Range(0, 99)] public int ExpiryTwoDigitYear { get; set; }
    [Required] public int Cvv { get; set; }

    public CreditCardWriteDto(string cardNumber, int expiryMonth, int expiryTwoDigitYear, int cvv)
    {
        CardNumber = cardNumber;
        ExpiryMonth = expiryMonth;
        ExpiryTwoDigitYear = expiryTwoDigitYear;
        Cvv = cvv;
    }
}