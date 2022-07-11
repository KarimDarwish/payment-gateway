using FluentAssertions;
using Moq;
using PaymentGateway.MockBank.Exceptions;
using PaymentGateway.MockBank.Model;
using PaymentGateway.MockBank.Services;
using PaymentGateway.MockBank.Services.RandomNumber;
using Xunit;

namespace MockBank.UnitTests;

public class PaymentServiceTests
{
    private readonly IPaymentService _service;
    private readonly Mock<IRandomNumberGenerator> _mockRandomNumberGenerator = new();

    public PaymentServiceTests()
    {
        _service = new PaymentService(_mockRandomNumberGenerator.Object);
    }

    [Fact]
    public void ProcessPayment_ifCvvHasFourCharacters_declinesPayment()
    {
        //Arrange
        var paymentRequest =
            new BankPaymentRequest(9.90m, "USD", new BankCreditCard("123 123 123 123 1234", 12, 29, 1234));

        _mockRandomNumberGenerator
            .Setup(service => service.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(0);

        //Act
        var response = _service.ProcessPayment(paymentRequest);

        //Assert
        response.PaymentAccepted.Should().BeFalse();
    }

    [Fact]
    public void ProcessPayment_ifValidCreditCard_approvesPayment()
    {
        //Arrange
        var paymentRequest =
            new BankPaymentRequest(9.90m, "USD", new BankCreditCard("123 123 123 123 1234", 12, 29, 123));

        _mockRandomNumberGenerator
            .Setup(service => service.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(0);

        //Act
        var response = _service.ProcessPayment(paymentRequest);

        //Assert
        response.PaymentAccepted.Should().BeTrue();
    }

    [Fact]
    public void ProcessPayment_ifRandomNumberMatches_throwsRateLimitException()
    {
        //Arrange
        var paymentRequest =
            new BankPaymentRequest(9.90m, "USD", new BankCreditCard("123 123 123 123 1234", 12, 29, 123));

        _mockRandomNumberGenerator
            .Setup(service => service.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(1);

        //Act
        var action = () => _service.ProcessPayment(paymentRequest);

        //Assert
        action.Should().Throw<BankRateLimitException>();
    }
}