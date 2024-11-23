using WebApplication3.Shared.Domain.Repositories;

namespace CarNest.TutorPaymentMethod.Domain.Repositories;

public interface ITutorPaymentMethodRepository : IBaseRepository<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod>
{
    Task<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod?> FindTutorPaymentMethodByIdAsync(int id);
}