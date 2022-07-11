namespace PaymentGateway.MockBank.Model;

public record BankPaymentRequest(decimal Amount, string Currency, BankCreditCard BankCreditCard);
