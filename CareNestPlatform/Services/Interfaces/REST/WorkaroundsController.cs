using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services.Application.CommandServices;
using WebApplication3.Services.Domain.Repositories;
using WebApplication3.Services.Interfaces.REST.Resources;
using WebApplication3.Services.Interfaces.REST.Transform;

namespace WebApplication3.Services.Interfaces.REST;

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
