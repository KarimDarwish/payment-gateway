using System;
using System.Net;
using System.Threading.Tasks;
using API.IntegrationTests.Configuration;
using API.IntegrationTests.Extensions;
using FluentAssertions;
using PaymentGateway.API.Commands.ProcessPayment;
using PaymentGateway.API.Models;
using Xunit;

namespace API.IntegrationTests.Payments;

public class GetPaymentIntegrationTests : IntegrationTest
{
    public GetPaymentIntegrationTests(WebApplicationFactoryFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task GetPayment_ifExists_returnsPayment()
    {
        //Arrange
        var command = new ProcessPaymentCommand
        {
            Amount = 9.90m,
            Currency = "GBP",
            CreditCard = new CreditCardDto
            {
                CardNumber = "123123213",
                Cvv = 123,
                ExpiryMonth = 12,
                ExpiryTwoDigitYear = 25
            }
        };

        var payment = await Client.ProcessPayment(command).Deserialize<PaymentProcessedResponse>();

        //Act
        var response = await Client.GetPayment(payment.PaymentId);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var deserialized = await response.Deserialize<GetPaymentResponse>();
        deserialized.PaymentId.Should().Be(payment.PaymentId);
    }

    [Fact]
    public async Task GetPayment_ifNotExisting_returnsNotFound()
    {
        //Arrange
        var invalidPaymentId = Guid.NewGuid();

        //Act
        var response = await Client.GetPayment(invalidPaymentId);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}