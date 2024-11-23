using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Domain.Repositories;

namespace CarNest.Services.Application.CommandServices;

public class WorkaroundCommandService
{
    private readonly IWorkaroundRepository _repository;

    public WorkaroundCommandService(IWorkaroundRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateWorkaroundsAsync(List<Workaround> workarounds)
    {
        await _repository.AddRangeAsync(workarounds);
    }
}