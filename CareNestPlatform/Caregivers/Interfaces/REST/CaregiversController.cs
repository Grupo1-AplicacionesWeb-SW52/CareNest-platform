using Microsoft.AspNetCore.Mvc;
using WebApplication3.Caregivers.Application.Internal.CommandServices;
using WebApplication3.Caregivers.Application.Internal.QueryServices;
using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Caregivers.Domain.Model.Commands;

namespace WebApplication3.Caregivers.Interfaces.REST
{
    [ApiController]
    [Route("api/caregivers")]
    public class CaregiversController : ControllerBase
    {
        private readonly CaregiverQueryService _queryService;
        private readonly CaregiverCommandService _commandService;

        public CaregiversController(CaregiverQueryService queryService, CaregiverCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var caregivers = await _queryService.GetAllAsync();
            return Ok(caregivers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var caregiver = await _queryService.GetByIdAsync(id);
            if (caregiver == null) return NotFound();
            return Ok(caregiver);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCaregiverCommand command)
        {
            await _commandService.CreateAsync(new Caregiver
            {
                FullName = command.FullName,
                Email = command.Email,
                Phone = command.Phone,
                Document = command.Document,
                Password = command.Password,
                ProfileImg = command.ProfileImg,
                Address = command.Address,
                District = command.District
            });
            return CreatedAtAction(nameof(GetById), new { id = command.Document }, null);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCaregiverCommand command)
        {
            if (id != command.Id) return BadRequest();
            var existing = await _queryService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _commandService.UpdateAsync(new Caregiver
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
            });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandService.DeleteAsync(id);
            return NoContent();
        }
    }
}
