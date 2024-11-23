using WebApplication3.Shared.Domain.Repositories;

namespace CarNest.CaregiverPaymentMethod.Domain.Repositories;

public interface ICaregiverPaymentMethodRepository: IBaseRepository<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>
{
    Task<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> FindCaregiverPaymentMethodByIdAsync(int id);
    
}

