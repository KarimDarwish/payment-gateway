using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace API.IntegrationTests.Configuration;

public abstract class IntegrationTest : IClassFixture<WebApplicationFactoryFixture>
{
    internal WebApplicationFactory<Program> Factory { get; }
    internal HttpClient Client { get; }

    protected IntegrationTest(WebApplicationFactoryFixture fixture)
    {
        Factory = fixture.Factory;
        Client = Factory.CreateClient();
    }
}