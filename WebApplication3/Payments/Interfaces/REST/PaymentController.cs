using Microsoft.AspNetCore.Mvc;
using WebApplication3.Payments.Domain.Model.Commands;
using WebApplication3.Payments.Domain.Model.Queries;
using WebApplication3.Payments.Domain.Services;
using WebApplication3.Payments.Interfaces.REST.Resources;
using WebApplication3.Payments.Interfaces.REST.Transform;

namespace WebApplication3.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/payments")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentCommandService _commandService;
    private readonly IPaymentQueryService _queryService;

    public PaymentController(
        IPaymentCommandService commandService,
        IPaymentQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // GET: api/v1/payments
    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var query = new GetAllPaymentQuery();
        var payments = await _queryService.Handle(query);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // GET: api/v1/payments/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var query = new GetPaymentByIdQuery(id);
        var payment = await _queryService.Handle(query);

        if (payment == null)
            return NotFound(new { Message = "Payment not found." });

        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(resource);
    }

    // POST: api/v1/payments
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = CreatePaymentFromResourceAssembler.ToCommandFromResource(resource);
        var createdPayment = await _commandService.Handle(command);

        if (createdPayment == null)
            return BadRequest(new { Message = "Failed to create payment." });

        var createdResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(createdPayment);
        return CreatedAtAction(nameof(GetPaymentById), new { id = createdResource.Id }, createdResource);
    }

    // PUT: api/v1/payments/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] UpdatePaymentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new UpdatePaymentCommand(
            id,
            resource.CardNumber,
            resource.CreatedAt,
            resource.Type,
            resource.Amount,
            resource.CaregiverId,
            resource.TutorId
        );

        try
        {
            var updatedPayment = await _commandService.Handle(command);

            if (updatedPayment == null)
                return NotFound(new { Message = "Payment not found." });

            var updatedResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(updatedPayment);
            return Ok(updatedResource);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    // DELETE: api/v1/payments/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        // This method assumes a Delete method in the repository/service (not provided in your code).
        // Implement it similarly to Update or Create.
        return StatusCode(StatusCodes.Status501NotImplemented, new { Message = "Delete operation not implemented." });
    }
}
