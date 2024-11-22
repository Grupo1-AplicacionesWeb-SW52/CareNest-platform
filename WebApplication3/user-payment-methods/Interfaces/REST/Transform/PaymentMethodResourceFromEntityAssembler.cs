using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Interfaces.REST.Resources;

namespace WebApplication3.user_payment_methods.Interfaces.REST.Transform;

public static class PaymentMethodResourceFromEntityAssembler
{
    public static PaymentMethodResource ToResourceFromEntity(UserPaymentMethod entity)
    {
        return new PaymentMethodResource(
            entity.Id,
            entity.CardNumber,
            entity.ExpirationDate,
            entity.Cvv,
            entity.CardHolder,
            entity.CaregiverId,
            entity.TutorId
        );
    } 
}