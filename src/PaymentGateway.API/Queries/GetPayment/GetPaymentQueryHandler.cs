using MediatR;
using PaymentGateway.API.Models;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Repositories;

namespace PaymentGateway.API.Queries.GetPayment;

public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentQueryResult>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public Task<GetPaymentQueryResult> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = _paymentRepository.Get(request.PaymentId);

        if (payment is null) return PaymentNotFound();

        return PaymentResponse(payment);
    }

    private Task<GetPaymentQueryResult> PaymentNotFound()
    {
        return Task.FromResult(new GetPaymentQueryResult(false, null));
    }

    private Task<GetPaymentQueryResult> PaymentResponse(Payment payment)
    {
        return Task.FromResult(new GetPaymentQueryResult(true, new GetPaymentResponse {PaymentId = payment.Id}));
    }
}