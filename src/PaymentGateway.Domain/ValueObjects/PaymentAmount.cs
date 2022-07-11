namespace PaymentGateway.Domain.ValueObjects;

public class PaymentAmount
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    public PaymentAmount(decimal amount, Currency currency)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), amount,
                "Only absolute values are allowed as payment amount");
        }

        Amount = amount;
        Currency = currency;
    }
}