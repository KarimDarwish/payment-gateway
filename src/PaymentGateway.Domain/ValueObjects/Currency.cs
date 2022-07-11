namespace PaymentGateway.Domain.ValueObjects;

public class Currency
{
    public string Name { get; }
    public string IsoCode { get; }

    public Currency(string name, string isoCode)
    {
        Name = name;
        IsoCode = isoCode;
    }
}

public static class Currencies
{
    public static readonly Currency BritishPound = new("British Pound Sterling", "GBP");
    public static readonly Currency Euro = new("Euro", "EUR");
    public static readonly Currency UsDollar = new("US Dollar", "USD");
}