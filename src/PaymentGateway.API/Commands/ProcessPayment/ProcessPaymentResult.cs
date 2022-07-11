namespace PaymentGateway.API.Commands.ProcessPayment;

public record ProcessPaymentResult(Guid PaymentId, string PaymentStatus);