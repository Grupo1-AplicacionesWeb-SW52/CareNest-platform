using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Interfaces.REST.Resources;

namespace CarNest.Reservations.Interfaces.REST.Transform{
    public static class ReservationResourceFromEntityAssembler
    {
        public static ReservationResource ToResourceFromEntity(Reservation entity)
        {
            return new ReservationResource(
                entity.Id,
                entity.CaregiverId,
                entity.TutorId,
                entity.StartDate,
                entity.EndDate,
                entity.Status,
                entity.TotalFare
            );
        }
    }
}