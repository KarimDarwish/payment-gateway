using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class CreditCardNumberMalformedException : DomainValidationException
{
    public CreditCardNumberMalformedException() : base(
        "The provided credit card number is malformed, expected 16 digits.")
    {
    }

    protected CreditCardNumberMalformedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}