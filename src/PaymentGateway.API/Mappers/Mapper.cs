using PaymentGateway.API.Models;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.API.Mappers;

public class Mapper
{
    public static CreditCard ToCreditCard(CreditCardDto dto)
    {
        var expiry = new CardExpiry(dto.ExpiryMonth, dto.ExpiryTwoDigitYear);
        var cvv = new CardVerificationValue(dto.Cvv);

        return new CreditCard(dto.CardNumber, expiry, cvv);
    }

    public static CreditCardDto ToCreditCardDto(CreditCard creditCard)
    {
        return new CreditCardDto
        {
            Cvv = creditCard.Cvv.Value,
            CardNumber = creditCard.CardNumber,
            ExpiryMonth = creditCard.ExpiryDate.Month,
            ExpiryTwoDigitYear = creditCard.ExpiryDate.Year
        };
    }

    public static Currency ToCurrency(string currency)
    {
        return Currencies.FromString(currency);
    }
}