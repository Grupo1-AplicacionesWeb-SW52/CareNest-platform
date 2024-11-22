using Microsoft.AspNetCore.Mvc;
using WebApplication3.user_payment_methods.Domain.Model.Commands;
using WebApplication3.user_payment_methods.Domain.Model.Queries;
using WebApplication3.user_payment_methods.Domain.Services;
using WebApplication3.user_payment_methods.Interfaces.REST.Resources;
using WebApplication3.user_payment_methods.Interfaces.REST.Transform;

namespace WebApplication3.user_payment_methods.Interfaces.REST;

[ApiController]
[Route("api/v1/payment-methods")]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodCommandService _commandService;
    private readonly IPaymentMethodQueryService _queryService;

    public PaymentMethodController(
        IPaymentMethodCommandService commandService,
        IPaymentMethodQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // GET: api/v1/payment-methods
    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var query = new GetAllPaymentMethodsQuery();
        var paymentMethods = await _queryService.Handle(query);
        var resources = paymentMethods.Select(PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // GET: api/v1/payment-methods/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaymentMethodById(int id)
    {
        var query = new GetPaymentMethodByIdQuery(id);
        var paymentMethod = await _queryService.Handle(query);

        if (paymentMethod == null)
            return NotFound(new { Message = "Payment method not found." });

        var resource = PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(paymentMethod);
        return Ok(resource);
    }

    // POST: api/v1/payment-methods
    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = CreatePaymentMethodFromResourceAssembler.ToCommandFromResource(resource);
        var createdPaymentMethod = await _commandService.Handle(command);

        if (createdPaymentMethod == null)
            return BadRequest(new { Message = "Failed to create payment method." });

        var createdResource = PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(createdPaymentMethod);
        return CreatedAtAction(nameof(GetPaymentMethodById), new { id = createdResource.Id }, createdResource);
    }

    // PUT: api/v1/payment-methods/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePaymentMethod(int id, [FromBody] UpdatePaymentMethodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var command = new UpdateUserPaymentCommand(
            id,
            resource.CardNumber,
            resource.ExpirationDate,
            resource.Cvv,
            resource.CardHolder,
            resource.CaregiverId,
            resource.TutorId
        );

        try
        {
            var updatedPaymentMethod = await _commandService.Handle(command);

            if (updatedPaymentMethod == null)
                return NotFound(new { Message = "Payment method not found." });

            var updatedResource = PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(updatedPaymentMethod);
            return Ok(updatedResource);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    // DELETE: api/v1/payment-methods/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePaymentMethod(int id)
    {
        // This method assumes a Delete method in the repository/service (not provided in your code).
        // Implement it similarly to Update or Create.
        return StatusCode(StatusCodes.Status501NotImplemented, new { Message = "Delete operation not implemented." });
    }
}