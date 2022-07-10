using System.Threading.Tasks;
using API.IntegrationTests.Configuration;
using FluentAssertions;
using Xunit;

namespace API.IntegrationTests;

public class UnitTest1 : IntegrationTest
{
    public UnitTest1(WebApplicationFactoryFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task DefaultEndpoint_returnsCorrectResponse()
    {
        //Act
        var response = await Client.GetAsync("/");

        //Assert
        var responseString = await response.Content.ReadAsStringAsync();

        responseString.Should().Contain("Hello World");
    }
}