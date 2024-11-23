using WebApplication3.user_payment_methods.Domain.Model.Aggregates;

namespace WebApplication3.user_payment_methods.Interfaces.ACL;

public interface IPaymentMethodContextFacade
{
    Task<int> CreatePaymentMethodAsync(Domain.Model.Aggregates.TutorPaymentMethod paymentMethod);
    
    Task<IEnumerable<Domain.Model.Aggregates.TutorPaymentMethod>> GetPaymentMethodsByUserAsync(int userId, string userType);

    Task<bool> DeletePaymentMethodAsync(int paymentMethodId);

}