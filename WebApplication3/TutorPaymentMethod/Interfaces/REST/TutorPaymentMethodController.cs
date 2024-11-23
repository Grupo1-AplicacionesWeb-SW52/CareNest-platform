using Microsoft.AspNetCore.Mvc;

using WebApplication3.TutorPaymentMethod.Domain.Services;
using WebApplication3.TutorPaymentMethod.Interfaces.REST.Resources;
using WebApplication3.TutorPaymentMethod.Interfaces.REST.Transform;

namespace WebApplication3.TutorPaymentMethod.Interfaces.REST;


[ApiController]
[Route("api/v1/tutor-payment-methods")]
public class TutorPaymentMethodController : ControllerBase
{
    private readonly ITutorPaymentMethodCommandService _commandService;
    private readonly ITutorPaymentMethodQueryService _queryService;

    public TutorPaymentMethodController(
        ITutorPaymentMethodCommandService commandService,
        ITutorPaymentMethodQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    // GET: api/v1/tutor-payment-methods
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new Domain.Model.Queries.GetAllTutorPaymentMethodQuery();
        var methods = await _queryService.Handle(query);

        var resources = methods.Select(TutorPaymentMethodResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // GET: api/v1/tutor-payment-methods/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new Domain.Model.Queries.GetTutorPaymentMethodByIdQuery(id);
        var method = await _queryService.Handle(query);

        if (method == null) return NotFound();

        var resource = TutorPaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(method);
        return Ok(resource);
    }

    // POST: api/v1/tutor-payment-methods
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTutorPaymentMethodResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var command = CreateTutorPaymentMethodFromResourceAssembler.ToCommandFromResourceTutor(
            new Domain.Model.Commands.CreateTutorPaymentMethodCommand(
                resource.CardNumber,
                resource.ExpirationDate,
                resource.Cvv,
                resource.CardHolder,
                resource.TutorId));

        var result = await _commandService.Handle(command);
        if (result == null) return BadRequest("Unable to create tutor payment method.");

        var createdResource = TutorPaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(result);
        return CreatedAtAction(nameof(GetById), new { id = createdResource.Id }, createdResource);
    }

    // PUT: api/v1/tutor-payment-methods/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTutorPaymentMethodResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var command = new Domain.Model.Commands.UpdateTutorPaymentMethodCommand(
            id,
            resource.CardNumber,
            resource.ExpirationDate,
            resource.Cvv,
            resource.CardHolder,
            resource.TutorId);

        var result = await _commandService.Handle(command);
        if (result == null) return NotFound();

        var updatedResource = TutorPaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(updatedResource);
    }
}