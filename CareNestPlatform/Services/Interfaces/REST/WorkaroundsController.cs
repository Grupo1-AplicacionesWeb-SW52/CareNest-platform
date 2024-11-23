using Microsoft.AspNetCore.Mvc;
using CarNest.Services.Application.CommandServices;
using CarNest.Services.Domain.Repositories;
using CarNest.Services.Interfaces.REST.Resources;
using CarNest.Services.Interfaces.REST.Transform;

namespace CarNest.Services.Interfaces.REST;

[ApiController]
[Route("api/workarounds")]
public class WorkaroundsController : ControllerBase
{
    private readonly IWorkaroundRepository _repository;
    private readonly WorkaroundCommandService _commandService;

    public WorkaroundsController(IWorkaroundRepository repository, WorkaroundCommandService commandService)
    {
        _repository = repository;
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkarounds([FromBody] CreateWorkaroundResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var workarounds = CreateWorkaroundCommandFromResourceAssembler.ToEntities(resource);
        await _commandService.CreateWorkaroundsAsync(workarounds);

        return Ok(workarounds);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkaroundById(int id)
    {
        var workaround = await _repository.GetByIdAsync(id);
        if (workaround == null) return NotFound();
        return Ok(workaround);
    }
}
