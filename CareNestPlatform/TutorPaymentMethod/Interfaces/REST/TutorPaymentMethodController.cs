using CarNest.TutorPaymentMethod.Domain.Model.Commands;
using CarNest.TutorPaymentMethod.Domain.Model.Queries;
using CarNest.TutorPaymentMethod.Domain.Services;
using CarNest.TutorPaymentMethod.Interfaces.REST.Resources;
using CarNest.TutorPaymentMethod.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace CarNest.TutorPaymentMethod.Interfaces.REST;


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
        var query = new GetAllTutorPaymentMethodQuery();
        var methods = await _queryService.Handle(query);

        var resources = methods.Select(TutorPaymentMethodResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    // GET: api/v1/tutor-payment-methods/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetTutorPaymentMethodByIdQuery(id);
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
            new CreateTutorPaymentMethodCommand(
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

        var command = new UpdateTutorPaymentMethodCommand(
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