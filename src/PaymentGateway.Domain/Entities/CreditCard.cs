using PaymentGateway.Domain.Exceptions;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Domain.Entities;

public class CreditCard
{
    public string CardNumber { get; }
    public CardExpiry ExpiryDate { get; }
    public CardVerificationValue Cvv { get; }

    public CreditCard(string cardNumber, CardExpiry expiryDate, CardVerificationValue cvv)
    {
        if (expiryDate.HasExpired) throw new CreditCardExpiredException();

        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
        Cvv = cvv;
    }
}