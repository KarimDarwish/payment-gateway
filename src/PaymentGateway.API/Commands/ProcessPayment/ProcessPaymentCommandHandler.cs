using MediatR;
using PaymentGateway.API.Mappers;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.ValueObjects;
using PaymentGateway.MockBank.Exceptions;
using PaymentGateway.MockBank.Services;
using Polly;
using Polly.Retry;

namespace PaymentGateway.API.Commands.ProcessPayment;

public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, ProcessPaymentResult>
{
    private readonly IPaymentRepository _repository;
    private readonly IPaymentService _paymentService;
    private readonly RetryPolicy _bankRetryPolicy;

    public ProcessPaymentCommandHandler(IPaymentRepository repository, IPaymentService paymentService)
    {
        _repository = repository;
        _paymentService = paymentService;
        
        _bankRetryPolicy = Policy.Handle<BankRateLimitException>()
            .WaitAndRetry(retryCount: 5, sleepDurationProvider: _ => TimeSpan.FromMilliseconds(50));
    }

    public Task<ProcessPaymentResult> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var creditCard = Mapper.ToCreditCard(request.CreditCard);
        var currency = Mapper.ToCurrency(request.Currency);

        var amount = new PaymentAmount(request.Amount, currency);
        var payment = new Payment(creditCard, amount);


        _bankRetryPolicy.Execute(() =>
        {
            var bankResponse = _paymentService.ProcessPayment(Mapper.ToBankPaymentRequest(payment));

            if (bankResponse.PaymentAccepted)
            {
                payment.Accept();
            }
            else
            {
                payment.Decline();
            }

            _repository.Insert(payment);
        });

        return Task.FromResult(new ProcessPaymentResult(payment.Id, payment.Status.ToString()));
    }
}