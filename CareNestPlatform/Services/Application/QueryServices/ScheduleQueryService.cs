using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Domain.Repositories;

namespace CarNest.Services.Application.QueryServices;

public class ScheduleQueryService
{
    private readonly IScheduleRepository _repository;

    public ScheduleQueryService(IScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Schedule?> GetScheduleByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}