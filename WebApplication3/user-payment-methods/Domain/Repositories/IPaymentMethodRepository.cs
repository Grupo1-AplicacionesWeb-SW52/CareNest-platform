using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;

namespace WebApplication3.user_payment_methods.Domain.Repositories;

public interface IPaymentMethodRepository: IBaseRepository<Model.Aggregates.TutorPaymentMethod>
{
    Task<Model.Aggregates.TutorPaymentMethod?> FindPaymentMethodByIdAsync(int id);
    
}

