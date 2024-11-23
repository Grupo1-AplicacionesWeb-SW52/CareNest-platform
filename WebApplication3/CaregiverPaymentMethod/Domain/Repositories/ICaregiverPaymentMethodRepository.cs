using WebApplication3.Shared.Domain.Repositories;

namespace WebApplication3.CaregiverPaymentMethod.Domain.Repositories;

public interface ICaregiverPaymentMethodRepository: IBaseRepository<Model.Aggregates.CaregiverPaymentMethod>
{
    Task<Model.Aggregates.CaregiverPaymentMethod?> FindCaregiverPaymentMethodByIdAsync(int id);
    
}

