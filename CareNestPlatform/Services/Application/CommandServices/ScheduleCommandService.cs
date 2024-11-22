using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Repositories;

namespace WebApplication3.Services.Application.CommandServices;

public class ScheduleCommandService {
    private readonly IScheduleRepository _repository;

    public ScheduleCommandService(IScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
    {
        await _repository.AddAsync(schedule);
        return schedule;
    }

    public void UpdateSchedule(Schedule schedule)
    {
        _repository.Update(schedule);
    }

    public void DeleteSchedule(int id)
    {
        var schedule = _repository.GetByIdAsync(id).Result;
        if (schedule != null)
        {
            _repository.Remove(schedule);
        }
    }
}