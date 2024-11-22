using WebApplication3.Caregivers.Domain.Repositories;
using WebApplication3.Caregivers.Domain.Model.Aggregates;

namespace WebApplication3.Caregivers.Application.Internal.CommandServices;

public class CaregiverCommandService
{
    private readonly ICaregiverRepository _repository;

    public CaregiverCommandService(ICaregiverRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Caregiver caregiver)
    {
        await _repository.AddAsync(caregiver);
    }

    public async Task UpdateAsync(Caregiver caregiver)
    {
        await _repository.UpdateAsync(caregiver);
    }

    public async Task DeleteAsync(int id)
    {
        var caregiver = await _repository.FindByIdAsync(id);
        if (caregiver != null) await _repository.RemoveAsync(caregiver);
    }
}