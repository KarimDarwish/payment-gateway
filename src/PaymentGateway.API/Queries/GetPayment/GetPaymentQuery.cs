using MediatR;

namespace PaymentGateway.API.Queries.GetPayment;

public record GetPaymentQuery(Guid PaymentId) : IRequest<GetPaymentQueryResult>;