using CarNest.Services.Domain.Model.Aggregates;

namespace CarNest.Services.Domain.Repositories;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> GetAllAsync();
    Task<Schedule?> GetByIdAsync(int id);
    Task AddAsync(Schedule schedule);
    void Update(Schedule schedule);
    void Remove(Schedule schedule);
}