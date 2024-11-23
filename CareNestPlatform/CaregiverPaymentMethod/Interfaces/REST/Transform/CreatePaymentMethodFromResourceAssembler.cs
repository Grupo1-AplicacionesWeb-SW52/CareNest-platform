using CarNest.CaregiverPaymentMethod.Domain.Model.Commands;
using CarNest.CaregiverPaymentMethod.Interfaces.REST.Resources;

namespace CarNest.CaregiverPaymentMethod.Interfaces.REST.Transform;

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
