using CarNest.TutorPaymentMethod.Interfaces.REST.Resources;

namespace CarNest.TutorPaymentMethod.Interfaces.REST.Transform;

public static class TutorPaymentMethodResourceFromEntityAssembler
{
    public static TutorPaymentMethodResource ToResourceFromEntity( CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod entity)
    {
        return new TutorPaymentMethodResource(
            entity.Id,
            entity.CardNumber,
            entity.ExpirationDate,
            entity.Cvv,
            entity.CardHolder,
            entity.TutorId
        );
    }
}