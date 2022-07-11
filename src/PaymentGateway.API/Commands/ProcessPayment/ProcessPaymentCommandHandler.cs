using MediatR;
using PaymentGateway.API.Mappers;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.API.Commands.ProcessPayment;

public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, ProcessPaymentResult>
{
    private readonly IPaymentRepository _repository;

    public ProcessPaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Task<ProcessPaymentResult> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var creditCard = Mapper.ToCreditCard(request.CreditCard);
        var currency = Mapper.ToCurrency(request.Currency);

        var amount = new PaymentAmount(request.Amount, currency);
        var payment = new Payment(creditCard, amount);

        _repository.Insert(payment);

        return Task.FromResult(new ProcessPaymentResult(payment.Id, payment.Status.ToString()));
    }
}