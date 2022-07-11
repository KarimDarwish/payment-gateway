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

    public static Currency ToCurrency(string currency)
    {
        return Currencies.FromString(currency);
    }
}