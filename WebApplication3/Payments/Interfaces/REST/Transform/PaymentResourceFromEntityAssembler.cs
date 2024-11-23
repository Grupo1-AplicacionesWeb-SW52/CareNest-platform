using WebApplication3.Payments.Domain.Model.Aggregates;
using WebApplication3.Payments.Interfaces.REST.Resources;

namespace WebApplication3.Payments.Interfaces.REST.Transform;

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