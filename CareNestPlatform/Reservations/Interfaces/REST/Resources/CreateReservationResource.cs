﻿namespace CarNest.Reservations.Interfaces.REST.Resources
{
    public record CreateReservationResource(
        int CaregiverId,
        int TutorId,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        decimal TotalFare
    );
}