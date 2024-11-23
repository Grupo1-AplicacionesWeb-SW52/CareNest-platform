namespace WebApplication3.Payments.Domain.Model.Commands;

public record UpdatePaymentCommand(
    int Id,                  // Payment identifier
    string CardNumber,       // Card number
    DateTime CreatedAt,      // Creation date
    string Type,             // Transaction type: "pay" or "deposit"
    decimal Amount,          // Transaction amount
    int? CaregiverId = null, // Caregiver ID (optional)
    int? TutorId = null      // Tutor ID (optional)
);