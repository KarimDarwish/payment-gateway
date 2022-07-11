namespace PaymentGateway.MockBank.Services.RandomNumber;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new();

    public int GenerateRandomNumber(int from, int to)
    {
        return _random.Next(from, to);
    }
}