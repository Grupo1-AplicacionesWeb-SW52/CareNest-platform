using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Model.Queries;

namespace CarNest.Reservations.Domain.Services
{
    public interface IReservationQueryService
    {
        Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery query);
        Task<Reservation?> Handle(GetReservationByIdQuery query);
    }
}