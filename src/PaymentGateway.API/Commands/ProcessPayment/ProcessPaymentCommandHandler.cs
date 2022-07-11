using MediatR;

namespace PaymentGateway.API.Commands.ProcessPayment;

public class ProcessPaymentCommandHandler: IRequestHandler<ProcessPaymentCommand, ProcessPaymentResult>
{
    public Task<ProcessPaymentResult> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}