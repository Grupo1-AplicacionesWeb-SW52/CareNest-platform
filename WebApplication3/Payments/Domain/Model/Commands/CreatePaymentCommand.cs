namespace WebApplication3.Payments.Domain.Model.Commands;

public record CreatePaymentCommand(
    string CardNumber,
    DateTime CreatedAt,
    string Type,
    decimal Amount,
    int? CaregiverId = null,
    int? TutorId = null
);