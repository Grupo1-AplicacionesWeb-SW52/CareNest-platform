using CarNest.Services.Domain.Model.Aggregates;

namespace CarNest.Services.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetByIdAsync(int id);
    Task AddAsync(Service service);
    void Update(Service service);
    void Remove(Service service);
}
