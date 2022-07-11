using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class CreditCardExpiredException : Exception
{
    public CreditCardExpiredException() : base("The provided credit card has expired")
    {
    }

    protected CreditCardExpiredException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}