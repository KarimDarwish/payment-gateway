using System.Net;
using System.Threading.Tasks;
using API.IntegrationTests.Builders;
using API.IntegrationTests.Configuration;
using API.IntegrationTests.Extensions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.API.Models;
using PaymentGateway.Domain.Enums;
using PaymentGateway.Domain.Repositories;
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
        response.Status.Should().Be(PaymentStatus.Processing.ToString());

        var repository = Factory.Services.GetRequiredService<IPaymentRepository>();
        repository.Get(response.PaymentId).Should().NotBeNull();
    }
}