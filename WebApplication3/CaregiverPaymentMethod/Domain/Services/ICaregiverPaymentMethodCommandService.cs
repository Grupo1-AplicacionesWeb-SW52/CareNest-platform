
using WebApplication3.CaregiverPaymentMethod.Domain.Model.Commands;

namespace WebApplication3.CaregiverPaymentMethod.Domain.Services;

public interface ICaregiverPaymentMethodCommandService
{
    Task<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(CreateCaregiverPaymentCommand command);
    
    Task<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(UpdateCaregiverPaymentCommand command);
}