namespace CarNest.Reservations.Domain.Model.Commands
{
    public record UpdateReservationCommand(
        int Id,
        int CaregiverId,
        int TutorId,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        decimal TotalFare
    );
}