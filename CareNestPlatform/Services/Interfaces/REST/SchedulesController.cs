using Microsoft.AspNetCore.Mvc;
using CarNest.Services.Application.CommandServices;
using CarNest.Services.Application.QueryServices;
using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Domain.Repositories;
using CarNest.Services.Interfaces.REST.Resources;
using CarNest.Services.Interfaces.REST.Transform;

namespace CarNest.Services.Interfaces.REST
{
    [ApiController]
    [Route("api/schedules")]
    public class SchedulesController : ControllerBase
    {
        private readonly ScheduleCommandService _commandService;
        private readonly ScheduleQueryService _queryService;
        private readonly IServiceRepository _serviceRepository;
        

        public SchedulesController(ScheduleCommandService commandService, ScheduleQueryService queryService, IServiceRepository serviceRepository)
        {
            _commandService = commandService;
            _queryService = queryService;
            _serviceRepository = serviceRepository; // Inicializar el repositorio
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _queryService.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await _queryService.GetScheduleByIdAsync(id);
            if (schedule == null) return NotFound();
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var schedule = CreateScheduleCommandFromResourceAssembler.ToEntity(resource);

            // Validar si el ServiceId es opcional
            if (schedule.ServiceId.HasValue)
            {
                var service = await _serviceRepository.GetByIdAsync(schedule.ServiceId.Value);
                if (service == null)
                    return NotFound($"Service with ID {schedule.ServiceId} not found.");
            }

            var createdSchedule = await _commandService.CreateScheduleAsync(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = createdSchedule.Id }, createdSchedule);
        }

        

        [HttpPut("{id}")]
        public IActionResult UpdateSchedule(int id, [FromBody] Schedule schedule)
        {
            if (id != schedule.Id) return BadRequest();
            _commandService.UpdateSchedule(schedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(int id)
        {
            _commandService.DeleteSchedule(id);
            return NoContent();
        }
    }
}
