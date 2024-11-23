namespace CarNest.Reservations.Domain.Model.Commands
{
    public record CreateReservationCommand(
        int CaregiverId,
        int TutorId,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        decimal TotalFare
    );
}