using WebApplication3.Payments.Domain.Model.Aggregates;
using WebApplication3.Payments.Domain.Model.Commands;

namespace WebApplication3.Payments.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payment?> Handle(CreatePaymentCommand command); // Handle creation of a payment
    
    Task<Payment?> Handle(UpdatePaymentCommand command); // Handle update of a payment
}