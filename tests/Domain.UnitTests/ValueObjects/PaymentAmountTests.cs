using System;
using FluentAssertions;
using PaymentGateway.Domain.Exceptions;
using PaymentGateway.Domain.ValueObjects;
using Xunit;

namespace Domain.UnitTests.ValueObjects;

public class PaymentAmountTests
{
    [Fact]
    public void Create_withValidAmount_creates()
    {
        //Act
        var amount = new PaymentAmount(10.3m, Currencies.BritishPound);

        //Assert
        amount.Should().NotBeNull();
        amount.Amount.Should().Be(10.3m);
        amount.Currency.Should().Be(Currencies.BritishPound);
    }

    [Fact]
    public void Create_withInvalidAmount_throws()
    {
        //Act
        var action = () => new PaymentAmount(-10.3m, Currencies.Euro);

        //Assert
        action.Should().Throw<InvalidPaymentAmountException>();
    }
}