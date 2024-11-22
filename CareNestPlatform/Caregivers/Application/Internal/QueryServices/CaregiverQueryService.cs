using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Caregivers.Domain.Repositories;

namespace WebApplication3.Caregivers.Application.Internal.QueryServices;

public class CaregiverQueryService
{
    private readonly ICaregiverRepository _repository;

    public CaregiverQueryService(ICaregiverRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Caregiver>> GetAllAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<Caregiver?> GetByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }
}