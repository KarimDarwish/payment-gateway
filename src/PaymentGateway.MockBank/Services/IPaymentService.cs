using PaymentGateway.MockBank.Model;

namespace PaymentGateway.MockBank.Services;

public interface IPaymentService
{
    BankPaymentResponse ProcessPayment(BankPaymentRequest bankPaymentRequest);
}