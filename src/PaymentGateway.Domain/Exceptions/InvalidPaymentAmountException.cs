using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class InvalidPaymentAmountException : DomainValidationException
{
    public InvalidPaymentAmountException() : base("Only absolute values are allowed as payment amount")
    {
    }

    protected InvalidPaymentAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}