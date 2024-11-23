using WebApplication3.CaregiverPaymentMethod.Domain.Model.Queries;
using WebApplication3.CaregiverPaymentMethod.Domain.Repositories;
using WebApplication3.CaregiverPaymentMethod.Domain.Services;

namespace WebApplication3.CaregiverPaymentMethod.Application.Internal.QueryServices;

public class CaregiverPaymentMethodQueryService : ICaregiverPaymentMethodQueryService
{
    private readonly ICaregiverPaymentMethodRepository _caregiverPaymentMethodRepository;

    public CaregiverPaymentMethodQueryService(ICaregiverPaymentMethodRepository caregiverPaymentMethodRepository)
    {
        _caregiverPaymentMethodRepository = caregiverPaymentMethodRepository;
    }

    public async Task<IEnumerable<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>> Handle(GetAllCaregiverPaymentMethodsQuery query)
    {
        return await _caregiverPaymentMethodRepository.ListAsync();
    }

    public async Task<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(GetCaregiverPaymentMethodByIdQuery query)
    {
        return await _caregiverPaymentMethodRepository.FindCaregiverPaymentMethodByIdAsync(query.Id);
    }
}