using WebApplication3.TutorPaymentMethod.Domain.Model.Queries;

namespace WebApplication3.TutorPaymentMethod.Domain.Services;

public interface ITutorPaymentMethodQueryService
{
    Task<IEnumerable<Model.Aggregates.TutorPaymentMethod>> Handle(GetAllTutorPaymentMethodQuery query);
    Task<Model.Aggregates.TutorPaymentMethod?> Handle(GetTutorPaymentMethodByIdQuery query);
}