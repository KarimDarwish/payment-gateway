using System;
using API.IntegrationTests.TestServices;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using PaymentGateway.MockBank.Services.RandomNumber;

namespace API.IntegrationTests.Configuration;

public class WebApplicationFactoryFixture : IDisposable
{
    internal WebApplicationFactory<Program> Factory { get; }

    public WebApplicationFactoryFixture()
    {
        Factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IRandomNumberGenerator, TestRandomNumberGenerator>();
            });
        });
    }

    public void Dispose()
    {
        Factory.Dispose();
    }
}