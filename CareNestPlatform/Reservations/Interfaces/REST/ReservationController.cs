using CarNest.Reservations.Domain.Model.Commands;
using CarNest.Reservations.Domain.Model.Queries;
using CarNest.Reservations.Domain.Services;

namespace CarNest.Reservations.Interfaces.REST
{
    using Microsoft.AspNetCore.Mvc;
    using CarNest.Reservations.Domain.Model.Commands;
    using CarNest.Reservations.Domain.Model.Queries;
    using CarNest.Reservations.Domain.Services;
    using CarNest.Reservations.Interfaces.REST.Resources;
    using CarNest.Reservations.Interfaces.REST.Transform;

    [ApiController]
    [Route("api/v1/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationCommandService _commandService;
        private readonly IReservationQueryService _queryService;

        public ReservationController(
            IReservationCommandService commandService,
            IReservationQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // GET: api/v1/reservations
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var query = new GetAllReservationsQuery();
            var reservations = await _queryService.Handle(query);
            var resources = reservations.Select(ReservationResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        // GET: api/v1/reservations/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var query = new GetReservationByIdQuery(id);
            var reservation = await _queryService.Handle(query);

            if (reservation == null)
                return NotFound(new { Message = "Reservation not found." });

            var resource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(reservation);
            return Ok(resource);
        }

        // POST: api/v1/reservations
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = CreateReservationFromResourceAssembler.ToCommandFromResource(resource);
            var createdReservation = await _commandService.Handle(command);

            if (createdReservation == null)
                return BadRequest(new { Message = "Failed to create reservation." });

            var createdResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(createdReservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = createdResource.Id }, createdResource);
        }

        // PUT: api/v1/reservations/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] UpdateReservationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdateReservationCommand(
                id,
                resource.CaregiverId,
                resource.TutorId,
                resource.StartDate,
                resource.EndDate,
                resource.Status,
                resource.TotalFare
            );

            var updatedReservation = await _commandService.Handle(command);

            if (updatedReservation == null)
                return NotFound(new { Message = "Reservation not found." });

            var updatedResource = ReservationResourceFromEntityAssembler.ToResourceFromEntity(updatedReservation);
            return Ok(updatedResource);
        }

        // DELETE: api/v1/reservations/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            // Implement delete functionality if needed
            return StatusCode(StatusCodes.Status501NotImplemented, new { Message = "Delete operation not implemented." });
        }
    }
}