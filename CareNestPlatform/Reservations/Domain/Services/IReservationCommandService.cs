using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Model.Commands;

namespace CarNest.Reservations.Domain.Services
{
    public interface IReservationCommandService
    {
        Task<Reservation?> Handle(CreateReservationCommand command);
        Task<Reservation?> Handle(UpdateReservationCommand command);
    }
}