using PaymentGateway.Domain.Enums;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Domain.Entities;

public class Payment
{
    public Guid Id { get; }
    public CreditCard CreditCard { get; }
    public PaymentAmount Amount { get; }
    public PaymentStatus Status { get; private set; }

    public Payment(CreditCard creditCard, PaymentAmount amount)
    {
        Id = Guid.NewGuid();
        CreditCard = creditCard;
        Amount = amount;
        Status = PaymentStatus.Processing;
    }

    public void Accept()
    {
        Status = PaymentStatus.Completed;
    }
    
    public void Decline()
    {
        Status = PaymentStatus.Declined;
    }
}