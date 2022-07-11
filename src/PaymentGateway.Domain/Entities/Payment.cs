using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Domain.Entities;

public class Payment
{
    public Guid Id { get; }
    public CreditCard CreditCard { get; }
    public PaymentAmount Amount { get; }

    public Payment(CreditCard creditCard, PaymentAmount amount)
    {
        Id = Guid.NewGuid();
        CreditCard = creditCard;
        Amount = amount;
    }
}