using CareNestPlatform.Payments.Domain.Model.Commands;
using CareNestPlatform.Payments.Interfaces.REST.Resources;

namespace CareNestPlatform.Payments.Interfaces.REST.Transform;

public static class CreatePaymentFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(
        CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(
            resource.CardNumber,
            resource.CreatedAt,
            resource.Type,
            resource.Amount,
            resource.CaregiverId,
            resource.TutorId
        );
    }
}