namespace PaymentGateway.MockBank.Services.RandomNumber;

public interface IRandomNumberGenerator
{
    int GenerateRandomNumber(int from, int to);
}