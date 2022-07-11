using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.ValueObjects;

public class MaskedCreditCardNumber
{
    public string Value { get; }

    private MaskedCreditCardNumber(string creditCardNumber)
    {
        var maskedNumber = creditCardNumber.Select((character, index) =>
        {
            var isInLastFourDigits = index >= creditCardNumber.Length - 4;
            if (isInLastFourDigits) return character;

            return char.IsDigit(character) ? '*' : character;
        });

        Value = new string(maskedNumber.ToArray());
    }

    //Factory method to ensure that all credit card numbers are valid at this point
    public static MaskedCreditCardNumber FromCreditCard(CreditCard creditCard)
    {
        return new MaskedCreditCardNumber(creditCard.CardNumber);
    }
}