using CareNestPlatform.Payments.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Domain.Model.Commands;

namespace CareNestPlatform.Payments.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payment?> Handle(CreatePaymentCommand command); // Handle creation of a payment
    
    Task<Payment?> Handle(UpdatePaymentCommand command); // Handle update of a payment
}