using MediatR;
using PaymentGateway.Domain.Repositories;

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
        return Task.FromResult(new ProcessPaymentResult());
    }
}