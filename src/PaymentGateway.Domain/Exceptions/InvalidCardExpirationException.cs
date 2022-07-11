using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class InvalidCardExpirationException : DomainValidationException
{
    public InvalidCardExpirationException(string message) : base(message)
    {
    }

    protected InvalidCardExpirationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}