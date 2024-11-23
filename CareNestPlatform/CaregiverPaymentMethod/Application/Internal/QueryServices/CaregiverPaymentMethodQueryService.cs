using CarNest.CaregiverPaymentMethod.Domain.Model.Queries;
using CarNest.CaregiverPaymentMethod.Domain.Repositories;
using CarNest.CaregiverPaymentMethod.Domain.Services;

namespace CarNest.CaregiverPaymentMethod.Application.Internal.QueryServices;

public class CaregiverPaymentMethodQueryService : ICaregiverPaymentMethodQueryService
{
    private readonly ICaregiverPaymentMethodRepository _caregiverPaymentMethodRepository;

    public CaregiverPaymentMethodQueryService(ICaregiverPaymentMethodRepository caregiverPaymentMethodRepository)
    {
        _caregiverPaymentMethodRepository = caregiverPaymentMethodRepository;
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.CaregiverPaymentMethod>> Handle(GetAllCaregiverPaymentMethodsQuery query)
    {
        return await _caregiverPaymentMethodRepository.ListAsync();
    }

    public async Task<Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(GetCaregiverPaymentMethodByIdQuery query)
    {
        return await _caregiverPaymentMethodRepository.FindCaregiverPaymentMethodByIdAsync(query.Id);
    }
}