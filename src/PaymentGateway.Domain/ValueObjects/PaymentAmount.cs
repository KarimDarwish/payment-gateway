using PaymentGateway.Domain.Exceptions;

namespace PaymentGateway.Domain.ValueObjects;

public class PaymentAmount
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    public PaymentAmount(decimal amount, Currency currency)
    {
        if (amount < 0) throw new InvalidPaymentAmountException();

        Amount = amount;
        Currency = currency;
    }
}