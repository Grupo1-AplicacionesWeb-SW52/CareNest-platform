using WebApplication3.CaregiverPaymentMethod.Domain.Model.Commands;
using WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Resources;

namespace WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Transform;

public static class CreatePaymentMethodFromResourceAssembler
{
    public static CreateCaregiverPaymentCommand ToCommandFromResource(
        CreatePaymentMethodResource resource)
    {
        return new CreateCaregiverPaymentCommand(
            resource.CardNumber,
            resource.ExpirationDate,
            resource.Cvv,
            resource.CardHolder,
            resource.CaregiverId
        );
    }
}
