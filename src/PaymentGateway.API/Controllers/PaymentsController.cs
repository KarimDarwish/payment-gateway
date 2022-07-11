using System.Net;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.API.Commands.ProcessPayment;

namespace PaymentGateway.API.Controllers;

[ApiController]
[Route("api/payments")]
[Produces("application/json")]
public class PaymentsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult ProcessNewPayment([FromBody] ProcessPaymentCommand command)
    {
        return new StatusCodeResult((int) HttpStatusCode.Created);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetPaymentById()
    {
        return Ok();
    }
}