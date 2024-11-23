
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Model.Commands;

namespace WebApplication3.user_payment_methods.Domain.Services;

public interface IPaymentMethodCommandService
{
    Task<Model.Aggregates.TutorPaymentMethod?> Handle(CreateUserPaymentCommand command);
    
    Task<Model.Aggregates.TutorPaymentMethod?> Handle(UpdateUserPaymentCommand command);
}