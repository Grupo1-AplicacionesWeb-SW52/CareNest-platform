using CarNest.Services.Domain.Model.Aggregates;
using CarNest.Services.Domain.Repositories;
using CarNest.Services.Domain.Services;

namespace CarNest.Services.Application.CommandServices;

public class ServiceCommandService : IServiceCommandService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceCommandService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Service> CreateServiceAsync(Service service)
    {
        await _serviceRepository.AddAsync(service);
        return service;
    }

    public void UpdateService(Service service)
    {
        _serviceRepository.Update(service);
    }

    public void DeleteService(int serviceId)
    {
        var service = _serviceRepository.GetByIdAsync(serviceId).Result;
        if (service == null) throw new Exception("Service not found.");
        _serviceRepository.Remove(service);
    }
}