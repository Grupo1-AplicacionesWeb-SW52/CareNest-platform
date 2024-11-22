using WebApplication3.user_payment_methods.Domain.Model.Aggregates;

namespace WebApplication3.user_payment_methods.Interfaces.ACL;

public interface IPaymentMethodContextFacade
{
    Task<int> CreatePaymentMethodAsync(UserPaymentMethod paymentMethod);
    
    Task<IEnumerable<UserPaymentMethod>> GetPaymentMethodsByUserAsync(int userId, string userType);

    Task<bool> DeletePaymentMethodAsync(int paymentMethodId);

}