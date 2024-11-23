using CarNest.Reservations.Domain.Model.Aggregates;

namespace CarNest.Reservations.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> ListAsync();                  // Obtener todas las reservas
        Task<Reservation?> FindByIdAsync(int id);                    // Buscar por ID
        Task<IEnumerable<Reservation>> FindByStatusAsync(string status); // Buscar por estado
        Task AddAsync(Reservation reservation);                       // Crear una nueva reserva
        Task UpdateAsync(Reservation reservation);                    // Actualizar una reserva existente
        Task RemoveAsync(Reservation reservation);                    // Eliminar una reserva
    }
}