using WebApplication3.Services.Domain.Model.Aggregates;

namespace WebApplication3.Services.Domain.Repositories;

public interface IWorkaroundRepository
{
    Task<IEnumerable<Workaround>> GetAllAsync();
    Task<Workaround?> GetByIdAsync(int id);
    Task AddAsync(Workaround workaround);
    void Update(Workaround workaround);
    void Remove(Workaround workaround);
    Task AddRangeAsync(List<Workaround> workarounds);
}