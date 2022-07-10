using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace API.IntegrationTests.Configuration;

public class WebApplicationFactoryFixture : IDisposable
{
    internal WebApplicationFactory<Program> Factory { get; }

    public WebApplicationFactoryFixture()
    {
        Factory = new WebApplicationFactory<Program>();
    }

    public void Dispose()
    {
        Factory.Dispose();
    }
}