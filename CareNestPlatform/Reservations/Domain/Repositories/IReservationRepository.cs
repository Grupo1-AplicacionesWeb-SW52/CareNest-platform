using CarNest.Reservations.Domain.Model.Aggregates;
using WebApplication3.Shared.Domain.Repositories;

namespace CarNest.Reservations.Domain.Repositories
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<Reservation?> FindReservationByIdAsync(int id);
    }
}