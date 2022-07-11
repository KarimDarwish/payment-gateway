using System;
using FluentAssertions;
using PaymentGateway.Domain.ValueObjects;
using Xunit;

namespace Domain.UnitTests.ValueObjects;

public class CardVerificationValueTests
{
    [Theory]
    [InlineData(123)]
    [InlineData(1234)]
    public void Create_withValidCVVs_creates(int value)
    {
        //Act
        var cvv = new CardVerificationValue(value);

        //Assert
        cvv.Should().NotBeNull();
        cvv.Value.Should().Be(value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(-123)]
    [InlineData(-1234)]
    [InlineData(12)]
    [InlineData(12345)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    public void Create_withInvalidCvv_throws(int invalidValue)
    {
        //Act
        var action = () => new CardVerificationValue(invalidValue);

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}