using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.Payments.Domain.Model.Aggregates;

namespace WebApplication3.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<Payment?> FindPaymentByIdAsync(int id); // Find a payment by its ID
}