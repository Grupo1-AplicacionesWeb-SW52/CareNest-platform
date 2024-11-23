using CareNestPlatform.Payments.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Domain.Model.Queries;

namespace CareNestPlatform.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query);    // Handle query to get all payments
    Task<Payment?> Handle(GetPaymentByIdQuery query);                // Handle query to get a payment by ID
}