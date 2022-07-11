using System.Collections.Concurrent;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Exceptions;
using PaymentGateway.Domain.Repositories;

namespace PaymentGateway.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    //Using a dictionary over a list due to computational complexity
    //The ConcurrentDictionary can deal with concurrent updates to the data set (simulating database locking mechanisms)
    private readonly IDictionary<Guid, Payment> _payments = new ConcurrentDictionary<Guid, Payment>();

    public void Insert(Payment payment)
    {
        try
        {
            _payments.Add(payment.Id, payment);
        }
        catch (ArgumentException)
        {
            throw new PaymentAlreadyExistsException();
        }
    }

    public Payment? Get(Guid paymentId)
    {
        try
        {
            return _payments[paymentId];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
}