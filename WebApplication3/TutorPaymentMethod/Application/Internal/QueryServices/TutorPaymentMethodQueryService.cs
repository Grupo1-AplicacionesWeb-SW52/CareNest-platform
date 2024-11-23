using WebApplication3.TutorPaymentMethod.Domain.Model.Queries;
using WebApplication3.TutorPaymentMethod.Domain.Repositories;
using WebApplication3.TutorPaymentMethod.Domain.Services;

namespace WebApplication3.TutorPaymentMethod.Application.Internal.QueryServices;

public class TutorPaymentMethodQueryService : ITutorPaymentMethodQueryService
{
    private readonly ITutorPaymentMethodRepository _tutorPaymentMethodRepository;

    public TutorPaymentMethodQueryService(ITutorPaymentMethodRepository tutorPaymentMethodRepository)
    {
        _tutorPaymentMethodRepository = tutorPaymentMethodRepository;
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.TutorPaymentMethod>> Handle(
        GetAllTutorPaymentMethodQuery query)
    {
        return await _tutorPaymentMethodRepository.ListAsync();
    }
    
    public async Task<Domain.Model.Aggregates.TutorPaymentMethod?> Handle(GetTutorPaymentMethodByIdQuery query)
    {
        return await _tutorPaymentMethodRepository.FindTutorPaymentMethodByIdAsync(query.Id);
    }

}
