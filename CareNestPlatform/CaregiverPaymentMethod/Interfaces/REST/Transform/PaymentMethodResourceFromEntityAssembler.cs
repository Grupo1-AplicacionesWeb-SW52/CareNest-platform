using CarNest.CaregiverPaymentMethod.Interfaces.REST.Resources;

namespace CarNest.CaregiverPaymentMethod.Interfaces.REST.Transform;

public static class PaymentMethodResourceFromEntityAssembler
{
    public static PaymentMethodResource ToResourceFromEntity(CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod entity)
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