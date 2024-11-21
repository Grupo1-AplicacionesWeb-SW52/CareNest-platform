using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Tutors.Domain.Model.Aggregates;

namespace WebApplication3.Tutors.Domain.Repositories;

public interface ITutorRepository
{
    Task AddAsync(Tutor tutor);
    Task RemoveAsync(Tutor tutor);
    Task<IEnumerable<Tutor>> ListAsync();
    Task<Tutor?> FindByIdAsync(int id);
    Task UpdateAsync(Tutor tutor);
}