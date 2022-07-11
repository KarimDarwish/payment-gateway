using PaymentGateway.MockBank.Services;
using PaymentGateway.MockBank.Services.RandomNumber;

namespace API.IntegrationTests.TestServices;

public class TestRandomNumberGenerator : IRandomNumberGenerator
{
    public int GenerateRandomNumber(int from, int to)
    {
        return PaymentService.RateLimitNotHit;
    }
}