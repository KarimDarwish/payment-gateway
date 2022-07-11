using System.Globalization;
using PaymentGateway.Domain.Exceptions;

namespace PaymentGateway.Domain.ValueObjects;

public class CardExpiry
{
    public int Month { get; }
    public int Year { get; }
    public bool HasExpired { get; }

    public CardExpiry(int month, int twoDigitYear)
    {
        if (month is > 12 or < 1)
        {
            throw new InvalidCardExpirationException("Provided month is not within the allowed range of 1 - 12");
        }

        Month = month;
        Year = twoDigitYear;
        HasExpired = HasCreditCardExpired(Month, Year);
    }

    private static bool HasCreditCardExpired(int month, int year)
    {
        var dateOfExpiry = DateTimeOffset.ParseExact($"{month}/{year}", "MM/yy", CultureInfo.InvariantCulture);

        return dateOfExpiry < DateTimeOffset.UtcNow;
    }
}