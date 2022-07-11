using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Repositories;

public interface IPaymentRepository
{
    void Insert(Payment payment);
    Payment? Get(Guid paymentId);
}