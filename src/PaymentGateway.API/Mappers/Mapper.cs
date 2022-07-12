using PaymentGateway.API.Models;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;
using PaymentGateway.MockBank.Model;

namespace PaymentGateway.API.Mappers;

public static class Mapper
{
    public static CreditCard ToCreditCard(CreditCardWriteDto dto)
    {
        var expiry = new CardExpiry(dto.ExpiryMonth, dto.ExpiryTwoDigitYear);
        var cvv = new CardVerificationValue(dto.Cvv);

        return new CreditCard(dto.CardNumber, expiry, cvv);
    }

    public static CreditCardReadDto ToCreditCardReadDto(CreditCard creditCard)
    {
        return new CreditCardReadDto(creditCard.CardNumber, creditCard.ExpiryDate.Month, creditCard.ExpiryDate.Year);
    }

    public static Currency ToCurrency(string currency)
    {
        return Currencies.FromString(currency);
    }

    public static BankPaymentRequest ToBankPaymentRequest(Payment payment)
    {
        return new BankPaymentRequest(payment.Amount.Amount, payment.Amount.Currency.ToString(),
            ToBankCreditCard(payment.CreditCard));
    }

    private static BankCreditCard ToBankCreditCard(CreditCard creditCard)
    {
        return new BankCreditCard(creditCard.CardNumber, creditCard.ExpiryDate.Month, creditCard.ExpiryDate.Year,
            creditCard.Cvv.Value);
    }
}