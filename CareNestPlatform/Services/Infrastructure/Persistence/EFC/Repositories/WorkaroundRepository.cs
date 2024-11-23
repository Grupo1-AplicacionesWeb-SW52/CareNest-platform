using Microsoft.EntityFrameworkCore;
using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WebApplication3.Services.Infrastructure.Persistence.EFC.Repositories;

public class WorkaroundRepository : IWorkaroundRepository
{
    private readonly AppDbContext _context;

    public WorkaroundRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Workaround>> GetAllAsync()
    {
        return await _context.Workarounds.ToListAsync();
    }

    public async Task<Workaround?> GetByIdAsync(int id)
    {
        return await _context.Workarounds.FindAsync(id);
    }

    public async Task AddAsync(Workaround workaround)
    {
        await _context.Workarounds.AddAsync(workaround);
        await _context.SaveChangesAsync();
    }

    public void Update(Workaround workaround)
    {
        _context.Workarounds.Update(workaround);
        _context.SaveChanges();
    }

    public void Remove(Workaround workaround)
    {
        _context.Workarounds.Remove(workaround);
        _context.SaveChanges();
    }
    
    public async Task AddRangeAsync(List<Workaround> workarounds)
    {
        await _context.Workarounds.AddRangeAsync(workarounds);
        await _context.SaveChangesAsync();
    }

}