using Microsoft.AspNetCore.Mvc;
using WebApplication3.CaregiverPaymentMethod.Domain.Model.Commands;
using WebApplication3.CaregiverPaymentMethod.Domain.Model.Queries;
using WebApplication3.CaregiverPaymentMethod.Domain.Services;
using WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Resources;
using WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Transform;

namespace WebApplication3.CaregiverPaymentMethod.Interfaces.REST;

[ApiController]
[Route("api/v1/payment-methods")]
public class PaymentMethodController : ControllerBase
{
    private readonly ICaregiverPaymentMethodCommandService _commandService;
    private readonly ICaregiverPaymentMethodQueryService _queryService;

    public PaymentMethodController(
        ICaregiverPaymentMethodCommandService commandService,
        ICaregiverPaymentMethodQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // GET: api/v1/payment-methods
    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var query = new GetAllCaregiverPaymentMethodsQuery();
        var paymentMethods = await _queryService.Handle(query);
        var resources = paymentMethods.Select(PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // GET: api/v1/payment-methods/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaymentMethodById(int id)
    {
        var query = new GetCaregiverPaymentMethodByIdQuery(id);
        var paymentMethod = await _queryService.Handle(query);

        if (paymentMethod == null)
            return NotFound(new { Message = "Payment method not found." });

        var resource = PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(paymentMethod);
        return Ok(resource);
    }

    // POST: api/v1/payment-methods
    [HttpPost]
    public async Task<IActionResult> CreateCaregiverPaymentMethod([FromBody] CreatePaymentMethodResource resource)
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

        var command = new UpdateCaregiverPaymentCommand(
            id,
            resource.CardNumber,
            resource.ExpirationDate,
            resource.Cvv,
            resource.CardHolder,
            resource.CaregiverId
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