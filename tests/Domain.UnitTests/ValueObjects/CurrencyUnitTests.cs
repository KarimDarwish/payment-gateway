using FluentAssertions;
using PaymentGateway.Domain.Exceptions;
using PaymentGateway.Domain.ValueObjects;
using Xunit;

namespace Domain.UnitTests.ValueObjects;

public class CurrencyUnitTests
{
    [Theory]
    [InlineData("GBP")]
    [InlineData("EUR")]
    [InlineData("USD")]
    public void FromString_withValidCurrency_returnsCurrency(string isoCode)
    {
        //Act
        var currency = Currencies.FromString(isoCode);

        //Assert
        currency.Should().NotBeNull();
    }

    [Theory]
    [InlineData("CHF")]
    [InlineData("JPY")]
    [InlineData("NOK")]
    [InlineData("not-a-currency")]
    public void FromString_withInvalidCurrency_throws(string isoCode)
    {
        //Act
        var action = () => Currencies.FromString(isoCode);

        //Assert
        action.Should().Throw<InvalidCurrencyException>();
    }
}