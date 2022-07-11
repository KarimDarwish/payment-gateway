using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Exceptions;

[Serializable]
public class InvalidCurrencyException : Exception
{
    public InvalidCurrencyException(string givenCurrency) : base(
        $"The provided currency \"{givenCurrency}\" is not valid")
    {
    }

    protected InvalidCurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}