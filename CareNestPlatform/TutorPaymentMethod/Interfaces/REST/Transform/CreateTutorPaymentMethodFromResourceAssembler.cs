using CarNest.TutorPaymentMethod.Domain.Model.Commands;

namespace CarNest.TutorPaymentMethod.Interfaces.REST.Transform;

public static class CreateTutorPaymentMethodFromResourceAssembler
{
    public static CreateTutorPaymentMethodCommand ToCommandFromResourceTutor(
        CreateTutorPaymentMethodCommand resource)
    {
        return new CreateTutorPaymentMethodCommand(
            resource.CardNumber,
            resource.ExpirationDate,
            resource.Cvv,
            resource.CardHolder,
            resource.TutorId
        );
    }
}