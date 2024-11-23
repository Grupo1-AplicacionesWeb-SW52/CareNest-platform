using CareNestPlatform.Shared.Domain.Repositories;
using CareNestPlatform.Payments.Domain.Model.Aggregates;

namespace CareNestPlatform.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<Payment?> FindPaymentByIdAsync(int id); // Find a payment by its ID
}