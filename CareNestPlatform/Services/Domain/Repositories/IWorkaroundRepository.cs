using CarNest.Services.Domain.Model.Aggregates;

namespace CarNest.Services.Domain.Repositories;

public interface IWorkaroundRepository
{
    Task<IEnumerable<Workaround>> GetAllAsync();
    Task<Workaround?> GetByIdAsync(int id);
    Task AddAsync(Workaround workaround);
    void Update(Workaround workaround);
    void Remove(Workaround workaround);
    Task AddRangeAsync(List<Workaround> workarounds);
}