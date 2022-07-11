using PaymentGateway.API.Models;

namespace PaymentGateway.API.Queries.GetPayment;

public record GetPaymentQueryResult(bool Success, GetPaymentResponse? PaymentResponse);