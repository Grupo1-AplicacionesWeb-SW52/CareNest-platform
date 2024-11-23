using CarNest.TutorPaymentMethod.Domain.Model.Commands;

namespace CarNest.TutorPaymentMethod.Domain.Services;

public interface ITutorPaymentMethodCommandService
{
    Task<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod?> Handle(CreateTutorPaymentMethodCommand command);
    
    Task<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod?> Handle(UpdateTutorPaymentMethodCommand command);
}