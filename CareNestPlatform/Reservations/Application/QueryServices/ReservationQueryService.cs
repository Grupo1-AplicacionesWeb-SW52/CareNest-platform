using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Repositories;

namespace CarNest.Reservations.Application.QueryServices
{
    public class ReservationQueryService
    {
        private readonly IReservationRepository _repository;

        public ReservationQueryService(IReservationRepository repository)
        {
            _repository = repository;
        }

        // Obtener todas las reservas
        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _repository.ListAsync();
        }

        // Obtener una reserva por su ID
        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        // Obtener reservas por el estado
        public async Task<IEnumerable<Reservation>> GetByStatusAsync(string status)
        {
            return await _repository.FindByStatusAsync(status);
        }
    }
}
