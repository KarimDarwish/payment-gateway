using System.Net;
using System.Threading.Tasks;
using API.IntegrationTests.Configuration;
using API.IntegrationTests.Extensions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.API.Commands.ProcessPayment;
using PaymentGateway.API.Models;
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
        var command = new ProcessPaymentCommand
        {
            Amount = 9.90m,
            Currency = "GBP",
            CreditCard = new CreditCardDto
            {
                CardNumber = "123 456 789 1234567",
                Cvv = 123,
                ExpiryMonth = 12,
                ExpiryTwoDigitYear = 25
            }
        };

        //Act
        var responseMessage = await Client.ProcessPayment(command);

        //Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);

        var response = await responseMessage.Deserialize<PaymentProcessedResponse>();
        response.PaymentId.Should().NotBeEmpty();

        var repository = Factory.Services.GetRequiredService<IPaymentRepository>();
        repository.Get(response.PaymentId).Should().NotBeNull();
    }
}