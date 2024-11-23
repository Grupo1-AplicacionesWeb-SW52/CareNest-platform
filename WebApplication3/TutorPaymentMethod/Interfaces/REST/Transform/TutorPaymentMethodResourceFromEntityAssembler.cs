using WebApplication3.TutorPaymentMethod.Interfaces.REST.Resources;

namespace WebApplication3.TutorPaymentMethod.Interfaces.REST.Transform;

public static class TutorPaymentMethodResourceFromEntityAssembler
{
    public static TutorPaymentMethodResource ToResourceFromEntity( Domain.Model.Aggregates.TutorPaymentMethod entity)
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