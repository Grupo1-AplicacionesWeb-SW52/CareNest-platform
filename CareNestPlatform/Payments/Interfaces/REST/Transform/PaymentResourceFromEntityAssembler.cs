using CareNestPlatform.Payments.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Interfaces.REST.Resources;

namespace CareNestPlatform.Payments.Interfaces.REST.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Id,
            entity.CardNumber,
            entity.CreatedAt,
            entity.Type,
            entity.Amount,
            entity.CaregiverId,
            entity.TutorId
        );
    } 
}