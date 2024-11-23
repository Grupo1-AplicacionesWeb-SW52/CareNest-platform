using Microsoft.EntityFrameworkCore;
using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Domain.Repositories;
using CarNest.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CarNest.Services.Infrastructure.Persistence.EFC.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _context.Services
            .Include(s => s.Schedules)
            .ToListAsync();
    }

    public async Task<Service?> GetByIdAsync(int id)
    {
        return await _context.Services
            .Include(s => s.Schedules)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public void Update(Service service)
    {
        _context.Services.Update(service);
        _context.SaveChanges();
    }

    public void Remove(Service service)
    {
        _context.Services.Remove(service);
        _context.SaveChanges();
    }
}
