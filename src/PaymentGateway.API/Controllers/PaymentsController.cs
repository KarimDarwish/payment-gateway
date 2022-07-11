using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.API.Commands.ProcessPayment;
using PaymentGateway.API.Models;
using PaymentGateway.API.Queries.GetPayment;

namespace PaymentGateway.API.Controllers;

[ApiController]
[Route("api/payments")]
[Produces("application/json")]
public class PaymentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Processes a new payment from a shopper
    /// </summary>
    /// <param name="command">The command containing payment details (credit card, amount, etc.)</param>
    /// <returns>A newly created payment</returns>
    /// <response code="201">Returns the newly created payment including its ID</response>
    /// <response code="400">Returns the error message in case any validation errors occur</response>
    [HttpPost(Name = nameof(ProcessNewPayment))]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(PaymentProcessedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(PaymentProcessingFailedResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ProcessNewPayment([FromBody] ProcessPaymentCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            return BadRequest(new PaymentProcessingFailedResponse(result.ErrorMessage));
        }

        var response = new PaymentProcessedResponse
            {PaymentId = result.PaymentId.GetValueOrDefault(), Status = result.PaymentStatus};

        return CreatedAtAction(nameof(GetPayment), new {id = response.PaymentId}, response);
    }

    /// <summary>
    /// Allows one to get a specific payment using its ID
    /// </summary>
    /// <param name="id">The identifier of the payment</param>
    /// <returns>The payment object</returns>
    /// <response code="200">Returns the payment with the corresponding ID</response>
    /// <response code="404">Returned if no payment with the given ID exists</response>
    [HttpGet("{id:guid}", Name = nameof(GetPayment))]
    [ProducesResponseType(typeof(GetPaymentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetPayment([Required] Guid id)
    {
        var (success, response) = await _mediator.Send(new GetPaymentQuery(id));

        if (!success) return NotFound();

        return Ok(response);
    }
}