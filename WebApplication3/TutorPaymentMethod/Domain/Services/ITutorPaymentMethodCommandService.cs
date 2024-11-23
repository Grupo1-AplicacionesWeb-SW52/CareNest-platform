using WebApplication3.TutorPaymentMethod.Domain.Model.Commands;

namespace WebApplication3.TutorPaymentMethod.Domain.Services;

public interface ITutorPaymentMethodCommandService
{
    Task<Model.Aggregates.TutorPaymentMethod?> Handle(CreateTutorPaymentMethodCommand command);
    
    Task<Model.Aggregates.TutorPaymentMethod?> Handle(UpdateTutorPaymentMethodCommand command);
}