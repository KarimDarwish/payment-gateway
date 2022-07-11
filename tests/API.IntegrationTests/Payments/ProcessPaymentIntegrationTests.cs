using System.Net;
using System.Threading.Tasks;
using API.IntegrationTests.Builders;
using API.IntegrationTests.Configuration;
using API.IntegrationTests.Extensions;
using FluentAssertions;
using PaymentGateway.API.Models;
using PaymentGateway.Domain.Enums;
using Xunit;

namespace API.IntegrationTests.Payments;

public class ProcessPaymentIntegrationTests : IntegrationTest
{
    public ProcessPaymentIntegrationTests(WebApplicationFactoryFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task ProcessPayment_withValidPaymentDetails_returnsCreated()
    {
        //Arrange
        var command = new ProcessPaymentCommandBuilder()
            .WithAmount(9.90m)
            .WithCurrency("USD")
            .WithCreditCardNumber("123 456 789 1234567")
            .WithCreditCardCvv(123)
            .WithCreditCardExpiration(12, 25)
            .Build();

        //Act
        var responseMessage = await Client.ProcessPayment(command);

        //Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);

        var response = await responseMessage.Deserialize<PaymentProcessedResponse>();
        response.PaymentId.Should().NotBeEmpty();
        response.Status.Should().Be(PaymentStatus.Completed.ToString());
    }
    
    [Fact]
    public async Task ProcessPayment_withCardGettingDeclined_returnsDeclinedPayment()
    {
        //Arrange
        var command = new ProcessPaymentCommandBuilder()
            .WithAmount(9.90m)
            .WithCurrency("USD")
            .WithCreditCardNumber("123 456 789 1234567")
            .WithCreditCardCvv(1234)
            .WithCreditCardExpiration(12, 25)
            .Build();

        //Act
        var responseMessage = await Client.ProcessPayment(command);

        //Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);

        var paymentResponse = await responseMessage.Deserialize<PaymentProcessedResponse>();
        paymentResponse.PaymentId.Should().NotBeEmpty();
        paymentResponse.Status.Should().Be(PaymentStatus.Declined.ToString());
    }
}