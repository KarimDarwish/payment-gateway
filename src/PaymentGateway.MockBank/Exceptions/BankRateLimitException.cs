using System.Runtime.Serialization;

namespace PaymentGateway.MockBank.Exceptions;

[Serializable]
public class BankRateLimitException : Exception
{
    public BankRateLimitException() : base("You are sending too many requests - please slow down!")
    {
    }

    protected BankRateLimitException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}