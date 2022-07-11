namespace PaymentGateway.Domain.ValueObjects;

public class CardVerificationValue
{
    public int Value { get; }

    public CardVerificationValue(int value)
    {
        var lengthOfValue = value.ToString().Length;

        if (value < 0 || lengthOfValue is < 3 or > 4)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value,
                "The provided CVV is not formatted correctly, expected an absolute number with 3 or 4 digits");
        }

        Value = value;
    }
}