using CarNest.CaregiverPaymentMethod.Domain.Model.Queries;

namespace CarNest.CaregiverPaymentMethod.Domain.Services;

public interface ICaregiverPaymentMethodQueryService
{
    Task<IEnumerable<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>> Handle(GetAllCaregiverPaymentMethodsQuery query);   
    Task<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(GetCaregiverPaymentMethodByIdQuery query); 
}

