using System;
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

public class GetPaymentIntegrationTests : IntegrationTest
{
    public GetPaymentIntegrationTests(WebApplicationFactoryFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task GetPayment_ifExists_returnsPayment()
    {
        //Arrange
        var command = new ProcessPaymentCommandBuilder().Build();

        var payment = await Client.ProcessPayment(command).Deserialize<PaymentProcessedResponse>();

        //Act
        var response = await Client.GetPayment(payment.PaymentId);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var paymentResponse = await response.Deserialize<GetPaymentResponse>();
        paymentResponse.PaymentId.Should().Be(payment.PaymentId);
        paymentResponse.Amount.Should().Be(command.Amount);
        paymentResponse.Currency.Should().Be(command.Currency);
        paymentResponse.CreditCard.Should().NotBeNull();
        paymentResponse.Status.Should().Be(PaymentStatus.Completed.ToString());
    }

    [Fact]
    public async Task GetPayment_ifExists_returnsMaskedCreditCardNumber()
    {
        //Arrange
        const string givenCreditCardNumber = "123 456 789 123 9999";

        var command = new ProcessPaymentCommandBuilder()
            .WithCreditCardNumber(givenCreditCardNumber)
            .Build();

        var payment = await Client.ProcessPayment(command).Deserialize<PaymentProcessedResponse>();

        //Act
        var response = await Client.GetPayment(payment.PaymentId);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        const string expectedCreditCardNumber = "*** *** *** *** 9999";

        var paymentResponse = await response.Deserialize<GetPaymentResponse>();
        paymentResponse.CreditCard.Should().NotBeNull();
        paymentResponse.CreditCard?.CardNumber.Should().Be(expectedCreditCardNumber);
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