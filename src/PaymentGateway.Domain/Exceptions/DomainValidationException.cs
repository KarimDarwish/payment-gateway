using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public abstract class DomainValidationException : Exception
{
    protected DomainValidationException(string? message) : base(message)
    {
    }

    protected DomainValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}