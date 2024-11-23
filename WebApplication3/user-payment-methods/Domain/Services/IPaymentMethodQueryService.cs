using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Model.Queries;

namespace WebApplication3.user_payment_methods.Domain.Services;

public interface IPaymentMethodQueryService
{
    Task<IEnumerable<Model.Aggregates.TutorPaymentMethod>> Handle(GetAllPaymentMethodsQuery query);   
    Task<Model.Aggregates.TutorPaymentMethod?> Handle(GetPaymentMethodByIdQuery query); 
}

