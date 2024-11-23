using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.ServiceDetail.Domain.Model.Aggregates;
using WebApplication3.ServiceDetail.Domain.Repositories;

namespace WebApplication3.ServiceDetail.Interfaces.ASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceDetailController : ControllerBase
    {
        private readonly IServiceDetailRepository _repository;

        public ServiceDetailController(IServiceDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var serviceDetails = await _repository.GetAllAsync();
            return Ok(serviceDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceDetail = await _repository.GetByIdAsync(id);
            if (serviceDetail == null) return NotFound();
            return Ok(serviceDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceDetail serviceDetail)
        {
            await _repository.AddAsync(serviceDetail);
            return CreatedAtAction(nameof(GetById), new { id = serviceDetail.Id }, serviceDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceDetail serviceDetail)
        {
            if (id != serviceDetail.Id) return BadRequest();
            await _repository.UpdateAsync(serviceDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
