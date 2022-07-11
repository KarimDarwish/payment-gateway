namespace PaymentGateway.API.Commands.ProcessPayment;

public record ProcessPaymentResult
{
    public bool Success { get; }
    public Guid? PaymentId { get; }
    public string? PaymentStatus { get; }
    public string? ErrorMessage { get; }

    public ProcessPaymentResult(Guid paymentId, string paymentStatus)
    {
        Success = true;
        PaymentId = paymentId;
        PaymentStatus = paymentStatus;
        ErrorMessage = null;
    }

    public ProcessPaymentResult(string errorMessage)
    {
        Success = false;
        ErrorMessage = errorMessage;
    }
};