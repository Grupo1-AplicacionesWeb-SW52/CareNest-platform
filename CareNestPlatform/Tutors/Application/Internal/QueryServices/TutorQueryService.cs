
using WebApplication3.Tutors.Domain.Model.Aggregates;
using WebApplication3.Tutors.Domain.Repositories;

namespace WebApplication3.Tutors.Application.Internal.QueryServices;

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