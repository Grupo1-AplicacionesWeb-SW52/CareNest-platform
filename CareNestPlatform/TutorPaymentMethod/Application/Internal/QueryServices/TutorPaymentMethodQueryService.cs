using CarNest.TutorPaymentMethod.Domain.Model.Queries;
using CarNest.TutorPaymentMethod.Domain.Repositories;
using CarNest.TutorPaymentMethod.Domain.Services;

namespace CarNest.TutorPaymentMethod.Application.Internal.QueryServices;

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
