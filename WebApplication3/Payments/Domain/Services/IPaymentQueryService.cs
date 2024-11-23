using WebApplication3.Payments.Domain.Model.Aggregates;
using WebApplication3.Payments.Domain.Model.Queries;

namespace WebApplication3.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query);    // Handle query to get all payments
    Task<Payment?> Handle(GetPaymentByIdQuery query);                // Handle query to get a payment by ID
}