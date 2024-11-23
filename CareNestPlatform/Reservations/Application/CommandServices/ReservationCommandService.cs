using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Repositories;
using CarNest.Reservations.Domain.Model.Commands;
using System.Threading.Tasks;

namespace CarNest.Reservations.Application.CommandServices
{
    public class ReservationCommandService
    {
        private readonly IReservationRepository _repository;

        public ReservationCommandService(IReservationRepository repository)
        {
            _repository = repository;
        }

        // Crear una nueva reserva a partir de un comando
        public async Task CreateAsync(CreateReservationCommand command)
        {
            var reservation = new Reservation(
                command.CaregiverId,
                command.TutorId,
                command.ServiceId,
                DateTime.Now, 
                command.StartTime,
                command.EndTime,
                command.TotalFare,
                ReservationStatus.Pending 
            );

            await _repository.AddAsync(reservation);
        }
        
        public async Task HandleAsync(CreateReservationCommand command)
        {
           
            var schedule = new Schedule(command.StartTime, command.EndTime); 
            var reservation = new Reservation
            {
                TutorId = command.TutorId,
                CaregiverId = command.CaregiverId,
                ServiceId = command.ServiceId,
                Status = ReservationStatus.Pending,  
                CreatedAt = DateTime.UtcNow,
                Schedule = schedule,
                TotalFare = command.TotalFare
            };

          
            await _repository.AddAsync(reservation);
        }



        // Actualizar una reserva existente
        public async Task UpdateAsync(Reservation reservation)
        {
            await _repository.UpdateAsync(reservation);
        }

        // Eliminar una reserva por su ID
        public async Task DeleteAsync(int id)
        {
            var reservation = await _repository.FindByIdAsync(id);
            if (reservation != null)
            {
                await _repository.RemoveAsync(reservation);
            }
        }
    }
}