namespace WebApplication3.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(
    string CardNumber,          // Card number
    DateTime CreatedAt,         // Creation date
    string Type,                // Transaction type ("pay" or "deposit")
    decimal Amount,             // Amount to be paid
    int? CaregiverId = null,    // Caregiver ID (optional)
    int? TutorId = null         // Tutor ID (optional)
);