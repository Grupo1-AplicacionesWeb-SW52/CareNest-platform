
using CarNest.Tutors.Domain.Model.Aggregates;
using CarNest.Tutors.Domain.Repositories;

namespace CarNest.Tutors.Application.Internal.QueryServices;

public class TutorQueryService
{
    private readonly ITutorRepository _repository;

    public TutorQueryService(ITutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<Tutor?> GetByIdAsync(int id)
    {
        return await _repository.FindByIdAsync(id);
    }
}