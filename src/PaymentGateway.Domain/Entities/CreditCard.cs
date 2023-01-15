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
        if (!IsCardNumberValid(cardNumber)) throw new CreditCardNumberMalformedException();

        CardNumber = cardNumber.Trim();
        ExpiryDate = expiryDate;
        Cvv = cvv;
    }

    private static bool IsCardNumberValid(string cardNumber)
    {
        var trimmedString = cardNumber.Replace(" ", string.Empty);

        var isAllDigits = trimmedString.All(char.IsDigit);
        var has16Characters = trimmedString.Length == 16;

        return isAllDigits && has16Characters;
    }
}
