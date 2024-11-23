using WebApplication3.Services.Domain.Model.Aggregates;
using WebApplication3.Services.Domain.Repositories;
using WebApplication3.Services.Domain.Services;

namespace WebApplication3.Services.Application.QueryServices;

public class ServiceQueryService : IServiceQueryService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceQueryService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<IEnumerable<Service>> GetAllServicesAsync()
    {
        return await _serviceRepository.GetAllAsync();
    }

    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        return await _serviceRepository.GetByIdAsync(id);
    }
}