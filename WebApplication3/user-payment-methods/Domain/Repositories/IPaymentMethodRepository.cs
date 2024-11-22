using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;

namespace WebApplication3.user_payment_methods.Domain.Repositories;

public interface IPaymentMethodRepository: IBaseRepository<UserPaymentMethod>
{
    Task<UserPaymentMethod?> FindPaymentMethodByIdAsync(int id);
    
}

