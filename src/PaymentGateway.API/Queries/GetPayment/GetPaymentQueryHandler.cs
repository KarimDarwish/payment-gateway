using MediatR;
using PaymentGateway.API.Mappers;
using PaymentGateway.API.Models;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.API.Queries.GetPayment;

public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentQueryResult>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<GetPaymentQueryResult> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = _paymentRepository.Get(request.PaymentId);

        if (payment is null) return new GetPaymentQueryResult(false, null);


        var creditCard = Mapper.ToCreditCardReadDto(payment.CreditCard) with
        {
            CardNumber = MaskedCreditCardNumber.FromCreditCard(payment.CreditCard).Value
        };

        var response = new GetPaymentResponse
        {
            PaymentId = payment.Id,
            Status = payment.Status.ToString(),
            Amount = payment.Amount.Amount,
            Currency = payment.Amount.Currency.ToString(),
            CreditCard = creditCard
        };

        return new GetPaymentQueryResult(true, response);
    }
}