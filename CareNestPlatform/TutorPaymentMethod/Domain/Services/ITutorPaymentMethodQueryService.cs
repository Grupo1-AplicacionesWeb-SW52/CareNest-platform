using CarNest.TutorPaymentMethod.Domain.Model.Queries;

namespace CarNest.TutorPaymentMethod.Domain.Services;

public interface ITutorPaymentMethodQueryService
{
    Task<IEnumerable<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod>> Handle(GetAllTutorPaymentMethodQuery query);
    Task<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod?> Handle(GetTutorPaymentMethodByIdQuery query);
}