using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class PaymentAlreadyExistsException : Exception
{
    public PaymentAlreadyExistsException() : base("A payment with this ID already exists")
    {
    }

    protected PaymentAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}