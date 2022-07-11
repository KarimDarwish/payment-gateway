using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentGateway.API.Commands.ProcessPayment;

namespace API.IntegrationTests.Extensions;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> ProcessPayment(this HttpClient client, ProcessPaymentCommand command)
    {
        return await client.PostAsync("api/payments",
            new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));
    }

    public static async Task<HttpResponseMessage> GetPayment(this HttpClient client, Guid paymentId)
    {
        return await client.GetAsync($"api/payments/{paymentId}");
    }
}