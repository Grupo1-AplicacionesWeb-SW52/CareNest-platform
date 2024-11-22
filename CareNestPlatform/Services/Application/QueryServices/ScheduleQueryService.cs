using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Repositories;

namespace WebApplication3.Services.Application.QueryServices;

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