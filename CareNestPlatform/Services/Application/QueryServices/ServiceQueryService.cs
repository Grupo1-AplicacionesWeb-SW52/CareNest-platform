using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Domain.Repositories;
using CarNest.Services.Domain.Services;

namespace CarNest.Services.Application.QueryServices;

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