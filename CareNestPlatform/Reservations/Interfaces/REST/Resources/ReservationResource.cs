namespace CarNest.Reservations.Interfaces.REST.Resources
{
    public record ReservationResource(
        int Id,
        int CaregiverId,
        int TutorId,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        decimal TotalFare
    );
}