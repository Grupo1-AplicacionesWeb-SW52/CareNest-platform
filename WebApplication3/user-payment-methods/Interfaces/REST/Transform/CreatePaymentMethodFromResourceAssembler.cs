using WebApplication3.user_payment_methods.Domain.Model.Commands;
using WebApplication3.user_payment_methods.Interfaces.REST.Resources;

namespace WebApplication3.user_payment_methods.Interfaces.REST.Transform;

public static class CreatePaymentMethodFromResourceAssembler
{
    public static CreateUserPaymentCommand ToCommandFromResource(
        CreatePaymentMethodResource resource)
    {
        return new CreateUserPaymentCommand(
            resource.CardNumber,
            resource.ExpirationDate,
            resource.Cvv,
            resource.CardHolder,
            resource.CaregiverId,
            resource.TutorId
        );
    }
}
