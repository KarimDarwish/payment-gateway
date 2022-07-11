using System.Net;
using System.Threading.Tasks;
using API.IntegrationTests.Configuration;
using API.IntegrationTests.Extensions;
using FluentAssertions;
using PaymentGateway.API.Commands.ProcessPayment;
using PaymentGateway.API.Models;
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
                CardNumber = "123123213",
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
    }
}