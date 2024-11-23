using WebApplication3.Payments.Domain.Model.Aggregates;

namespace WebApplication3.Payments.Interfaces.ACL;

public interface IPaymentContextFacade
{
    Task<int> CreatePaymentAsync(Payment payment);                         // Create a new payment
    
    Task<IEnumerable<Payment>> GetPaymentsByUserAsync(int userId, string userType); // Get payments by user and type
    
    Task<bool> DeletePaymentAsync(int paymentId);                          // Delete a payment
}