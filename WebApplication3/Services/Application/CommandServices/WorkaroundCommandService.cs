using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Repositories;

namespace WebApplication3.Services.Application.CommandServices;

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