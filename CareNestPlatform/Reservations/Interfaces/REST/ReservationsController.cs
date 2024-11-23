using CarNest.Reservations.Application.CommandServices;
using CarNest.Reservations.Application.QueryServices;
using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Model.Commands;
using CarNest.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarNest.Reservations.Interfaces.REST
{
    [Route("api/v1/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationCommandService _reservationCommandService;
        private readonly ReservationQueryService _reservationQueryService;

        public ReservationsController(ReservationCommandService reservationCommandService, ReservationQueryService reservationQueryService)
        {
            _reservationCommandService = reservationCommandService;
            _reservationQueryService = reservationQueryService;
        }

   
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            await _reservationCommandService.HandleAsync(command);
            return NoContent(); 
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationQueryService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        // Endpoint para obtener todas las reservas
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationQueryService.GetAllAsync();
            return Ok(reservations);
        }
    }
}
