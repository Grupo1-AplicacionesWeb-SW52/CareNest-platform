using WebApplication3.Services.Domain.Model.Aggregates;

namespace WebApplication3.Services.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllAsync();
    Task<Service?> GetByIdAsync(int id);
    Task AddAsync(Service service);
    void Update(Service service);
    void Remove(Service service);
}
