using PaymentGateway.Domain.Exceptions;

namespace PaymentGateway.Domain.ValueObjects;

public class CardVerificationValue
{
    public int Value { get; }

    public CardVerificationValue(int value)
    {
        var lengthOfValue = value.ToString().Length;

        if (value < 0 || lengthOfValue is < 3 or > 4)
        {
            throw new InvalidCardVerificationValueException();
        }

        Value = value;
    }
}