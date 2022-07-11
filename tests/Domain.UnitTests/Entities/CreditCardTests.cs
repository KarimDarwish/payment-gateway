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

    [Theory]
    [InlineData("123")]
    [InlineData("123 456 789 123456789")]
    [InlineData("not-even-a-number")]
    [InlineData("stringWith16Char")]
    public void Create_withInvalidCardNumber_throws(string cardNumber)
    {
        //Arrange
        var expired = new CardExpiry(12, 29);
        var cvv = new CardVerificationValue(123);

        //Act
        var action = () => new CreditCard(cardNumber, expired, cvv);

        //Assert
        action.Should().Throw<CreditCardNumberMalformedException>();
    }

    [Theory]
    [InlineData("123 456 789 1234567")]
    [InlineData("1234567891234567")]
    public void Create_withValidCardNumber_createsCreditCard(string cardNumber)
    {
        //Arrange
        var expired = new CardExpiry(12, 29);
        var cvv = new CardVerificationValue(123);

        //Act
        var creditCard = new CreditCard(cardNumber, expired, cvv);

        //Assert
        creditCard.Should().NotBeNull();
        creditCard.CardNumber.Should().Be(cardNumber);
    }
}