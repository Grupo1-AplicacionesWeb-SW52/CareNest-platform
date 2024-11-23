using WebApplication3.CaregiverPaymentMethod.Domain.Model.Queries;

namespace WebApplication3.CaregiverPaymentMethod.Domain.Services;

public interface ICaregiverPaymentMethodQueryService
{
    Task<IEnumerable<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>> Handle(GetAllCaregiverPaymentMethodsQuery query);   
    Task<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(GetCaregiverPaymentMethodByIdQuery query); 
}

