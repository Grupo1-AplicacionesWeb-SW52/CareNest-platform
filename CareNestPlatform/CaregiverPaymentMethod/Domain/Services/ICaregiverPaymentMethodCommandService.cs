
using CarNest.CaregiverPaymentMethod.Domain.Model.Commands;

namespace CarNest.CaregiverPaymentMethod.Domain.Services;

public interface ICaregiverPaymentMethodCommandService
{
    Task<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(CreateCaregiverPaymentCommand command);
    
    Task<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(UpdateCaregiverPaymentCommand command);
}