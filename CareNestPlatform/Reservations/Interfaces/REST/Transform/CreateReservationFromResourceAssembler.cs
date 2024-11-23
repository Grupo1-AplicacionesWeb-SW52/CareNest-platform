using CarNest.Reservations.Domain.Model.Commands;
using CarNest.Reservations.Interfaces.REST.Resources;

namespace CarNest.Reservations.Interfaces.REST.Transform
{
    public static class CreateReservationFromResourceAssembler
    {
        public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource)
        {
            return new CreateReservationCommand(
                resource.CaregiverId,
                resource.TutorId,
                resource.StartDate,
                resource.EndDate,
                resource.Status,
                resource.TotalFare
            );
        }
    }
}