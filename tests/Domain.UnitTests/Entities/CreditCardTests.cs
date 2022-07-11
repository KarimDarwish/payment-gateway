using FluentAssertions;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Exceptions;
using PaymentGateway.Domain.ValueObjects;
using Xunit;

namespace Domain.UnitTests.Entities;

public class CreditCardTests
{
    [Fact]
    public void Create_withExpiredCreditCard_throws()
    {
        //Arrange
        var expired = new CardExpiry(12, 19);
        var cvv = new CardVerificationValue(123);
        var cardNumber = "2222420000001113";

        //Act
        var action = () => new CreditCard(cardNumber, expired, cvv);

        //Assert
        action.Should().Throw<CreditCardExpiredException>();
    }
}