namespace PaymentGateway.MockBank.Model;

public record BankCreditCard(string CardNumber, int ExpiryMonth, int ExpiryTwoDigitYear, int Cvv);
