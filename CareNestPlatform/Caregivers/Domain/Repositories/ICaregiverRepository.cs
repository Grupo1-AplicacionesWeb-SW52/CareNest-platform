using CarNest.Caregivers.Domain.Model.Aggregates;

namespace CarNest.Caregivers.Domain.Repositories;

public interface ICaregiverRepository
{
    Task<IEnumerable<Caregiver>> ListAsync();
    Task<Caregiver?> FindByIdAsync(int id);
    Task AddAsync(Caregiver caregiver);
    Task UpdateAsync(Caregiver caregiver);
    Task RemoveAsync(Caregiver caregiver);
}