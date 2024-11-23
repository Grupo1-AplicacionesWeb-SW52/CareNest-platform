using WebApplication3.Shared.Domain.Repositories;

namespace WebApplication3.TutorPaymentMethod.Domain.Repositories;

public interface ITutorPaymentMethodRepository : IBaseRepository<Model.Aggregates.TutorPaymentMethod>
{
    Task<Model.Aggregates.TutorPaymentMethod?> FindTutorPaymentMethodByIdAsync(int id);
}