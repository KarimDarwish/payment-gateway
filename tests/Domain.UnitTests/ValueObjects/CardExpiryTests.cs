using System;
using FluentAssertions;
using PaymentGateway.Domain.ValueObjects;
using Xunit;

namespace Domain.UnitTests.ValueObjects;

public class CardExpiryTests
{
    [Fact]
    public void Create_withInvalidMonth_throws()
    {
        //Arrange
        var invalidMonth = 13;

        //Act
        var action = () => new CardExpiry(invalidMonth, 25);

        //Assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Create_withExpiredCard_isExpired()
    {
        //Arrange
        var expiredCardYear = 20;

        //Act
        var cardExpiry = new CardExpiry(12, expiredCardYear);

        //Assert
        cardExpiry.HasExpired.Should().BeTrue();
    }
    
    [Fact]
    public void Create_withValidCard_isNotExpired()
    {
        //Act
        var cardExpiry = new CardExpiry(12, 25);

        //Assert
        cardExpiry.HasExpired.Should().BeFalse();
    }
}