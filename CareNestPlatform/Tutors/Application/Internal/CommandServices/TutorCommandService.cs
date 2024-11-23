using CarNest.Caregivers.Domain.Model.Aggregates;
using CarNest.Caregivers.Domain.Repositories;
using CarNest.Tutors.Domain.Model.Aggregates;
using CarNest.Tutors.Domain.Repositories;

namespace CarNest.Tutors.Application.Internal.CommandServices;

public class TutorCommandService
{
    private readonly ITutorRepository _repository;

    public TutorCommandService(ITutorRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Tutor tutor)
    {
        await _repository.AddAsync(tutor);
    }

    public async Task UpdateAsync(Tutor tutor)
    {
        await _repository.UpdateAsync(tutor);
    }

    public async Task DeleteAsync(int id)
    {
        var tutor = await _repository.FindByIdAsync(id);
        if (tutor != null) await _repository.RemoveAsync(tutor);
    }
}