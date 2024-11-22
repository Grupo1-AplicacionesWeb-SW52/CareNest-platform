
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Model.Commands;

namespace WebApplication3.user_payment_methods.Domain.Services;

public interface IPaymentMethodCommandService
{
    Task<UserPaymentMethod?> Handle(CreateUserPaymentCommand command);
    
    Task<UserPaymentMethod?> Handle(UpdateUserPaymentCommand command);
}