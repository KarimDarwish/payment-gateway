using FluentAssertions;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;
using Xunit;

namespace Domain.UnitTests.ValueObjects;

public class MaskedCreditCardNumberTests
{
    [Theory]
    [InlineData("123 456 789 123 4567", "*** *** *** *** 4567")]
    [InlineData("123 456 789 123 4567 ", "*** *** *** *** 4567")]
    [InlineData("1234567891234567", "************4567")]
    public void FromCreditCard_withValidCardNumber_masksNumber(string givenCardNumber, string expectedMaskedCardNumber)
    {
        //Arrange
        var creditCard = new CreditCard(givenCardNumber, new CardExpiry(12, 29), new CardVerificationValue(123));

        //Act
        var maskedCardNumber = MaskedCreditCardNumber.FromCreditCard(creditCard);

        //Assert
        maskedCardNumber.Value.Should().Be(expectedMaskedCardNumber);
    }
}