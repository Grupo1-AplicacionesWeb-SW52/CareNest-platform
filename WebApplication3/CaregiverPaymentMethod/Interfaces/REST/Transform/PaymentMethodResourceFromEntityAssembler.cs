using WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Resources;

namespace WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Transform;

public static class PaymentMethodResourceFromEntityAssembler
{
    public static PaymentMethodResource ToResourceFromEntity(CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod entity)
    {
        return new PaymentMethodResource(
            entity.Id,
            entity.CardNumber,
            entity.ExpirationDate,
            entity.Cvv,
            entity.CardHolder,
            entity.CaregiverId
        );
    } 
}