using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WebApplication3.Services.Interfaces.REST;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var services = await _context.Services.Include(s => s.Schedules).ToListAsync();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var service = await _context.Services
            .Include(s => s.Schedules)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (service == null) return NotFound();
        return Ok(service);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Service service)
    {
        // Agregar el nuevo servicio
        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Service updatedService)
    {
        if (id != updatedService.Id) return BadRequest();

        var existingService = await _context.Services
            .Include(s => s.Schedules)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (existingService == null) return NotFound();

        // Actualizar los campos principales
        existingService.Description = updatedService.Description;
        existingService.FarePerHour = updatedService.FarePerHour;
        existingService.Rating = updatedService.Rating;

        // Actualizar los schedules
        _context.Schedules.RemoveRange(existingService.Schedules);
        existingService.Schedules = updatedService.Schedules;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}