using CarNest.Caregivers.Domain.Model.Aggregates;
using CarNest.Tutors.Domain.Model.Aggregates;

namespace CarNest.Tutors.Domain.Repositories;

public interface ITutorRepository
{
    Task AddAsync(Tutor tutor);
    Task RemoveAsync(Tutor tutor);
    Task<IEnumerable<Tutor>> ListAsync();
    Task<Tutor?> FindByIdAsync(int id);
    Task UpdateAsync(Tutor tutor);
}