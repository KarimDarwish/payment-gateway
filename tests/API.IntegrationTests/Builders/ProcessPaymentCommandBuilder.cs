using PaymentGateway.API.Commands.ProcessPayment;
using PaymentGateway.API.Models;

namespace API.IntegrationTests.Builders;

public class ProcessPaymentCommandBuilder
{
    private decimal _amount = 9.99m;
    private string _currency = "GBP";
    private string _creditCardNumber = "123 456 789 123 4567";
    private int _creditCardCvv = 123;
    private int _creditCardExpiryMonth = 12;
    private int _creditCardExpiryYear = 27;

    public ProcessPaymentCommandBuilder WithAmount(decimal amount)
    {
        _amount = amount;
        return this;
    }

    public ProcessPaymentCommandBuilder WithCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public ProcessPaymentCommandBuilder WithCreditCardNumber(string creditCardNumber)
    {
        _creditCardNumber = creditCardNumber;
        return this;
    }

    public ProcessPaymentCommandBuilder WithCreditCardCvv(int cvv)
    {
        _creditCardCvv = cvv;
        return this;
    }

    public ProcessPaymentCommandBuilder WithCreditCardExpiration(int month, int year)
    {
        _creditCardExpiryMonth = month;
        _creditCardExpiryYear = year;
        return this;
    }

    public ProcessPaymentCommand Build()
    {
        var creditCard = new CreditCardWriteDto(_creditCardNumber, _creditCardExpiryMonth, _creditCardExpiryYear,
            _creditCardCvv);

        return new ProcessPaymentCommand(_amount, _currency, creditCard);
    }
}