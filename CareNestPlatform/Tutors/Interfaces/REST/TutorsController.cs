using Microsoft.AspNetCore.Mvc;
using CarNest.Tutors.Application.Internal.CommandServices;
using CarNest.Tutors.Application.Internal.QueryServices;
using CarNest.Tutors.Domain.Model.Aggregates;
using CarNest.Tutors.Domain.Model.Commands;

namespace CarNest.Tutors.Interfaces.REST;

[ApiController]
[Route("api/tutors")]
public class TutorsController : ControllerBase
{
    private readonly TutorQueryService _queryService;
    private readonly TutorCommandService _commandService;

    public TutorsController(TutorQueryService queryService, TutorCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTutorCommand command)
    {
        var tutor = new Tutor
        {
            FullName = command.FullName,
            Email = command.Email,
            Phone = command.Phone,
            Document = command.Document,
            Password = command.Password,
            ProfileImg = command.ProfileImg,
            Address = command.Address,
            District = command.District
        };

        await _commandService.CreateAsync(tutor);
        return CreatedAtAction(nameof(GetById), new { id = tutor.Id }, tutor);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tutor = await _queryService.GetByIdAsync(id);
        if (tutor == null) return NotFound();
        return Ok(tutor);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTutorCommand command)
    {
        if (id != command.Id) return BadRequest();

        var existingTutor = await _queryService.GetByIdAsync(id);
        if (existingTutor == null) return NotFound();

        var tutor = new Tutor
        {
            Id = command.Id,
            FullName = command.FullName,
            Email = command.Email,
            Phone = command.Phone,
            Document = command.Document,
            Password = command.Password,
            ProfileImg = command.ProfileImg,
            Address = command.Address,
            District = command.District
        };

        await _commandService.UpdateAsync(tutor);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tutor = await _queryService.GetByIdAsync(id);
        if (tutor == null) return NotFound();

        await _commandService.DeleteAsync(id);
        return NoContent();
    }
}