using Microsoft.EntityFrameworkCore;
using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WebApplication3.Services.Infrastructure.Persistence.EFC.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly AppDbContext _context;

    public ScheduleRepository(AppDbContext context)
    {
        _context = context;
    }


    public Task<IEnumerable<Schedule>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Schedule?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
    }

    public void Update(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
        _context.SaveChanges();
    }

    public void Remove(Schedule schedule)
    {
        _context.Schedules.Remove(schedule);
        _context.SaveChanges();
    }
}
