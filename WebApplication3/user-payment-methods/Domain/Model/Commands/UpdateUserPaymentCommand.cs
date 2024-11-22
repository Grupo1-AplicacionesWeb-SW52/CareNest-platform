namespace WebApplication3.user_payment_methods.Domain.Model.Commands;

public record UpdateUserPaymentCommand(
    int Id,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int? CaregiverId = null,
    int? TutorId = null
    );