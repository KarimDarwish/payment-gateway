using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class InvalidCardVerificationValueException : DomainValidationException
{
    public InvalidCardVerificationValueException() : base(
        "The provided CVV is not formatted correctly, expected an absolute number with 3 or 4 digits")
    {
    }

    protected InvalidCardVerificationValueException(SerializationInfo info, StreamingContext context) : base(info,
        context)
    {
    }
}