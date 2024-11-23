using WebApplication3.Payments.Domain.Model.Commands;
using WebApplication3.Payments.Interfaces.REST.Resources;

namespace WebApplication3.Payments.Interfaces.REST.Transform;

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