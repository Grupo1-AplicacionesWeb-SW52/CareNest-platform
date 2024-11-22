using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Caregivers.Domain.Repositories;
using WebApplication3.Tutors.Domain.Model.Aggregates;
using WebApplication3.Tutors.Domain.Repositories;

namespace WebApplication3.Tutors.Application.Internal.CommandServices;

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