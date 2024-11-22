namespace WebApplication3.user_payment_methods.Domain.Model.Commands;

public record CreateUserPaymentCommand(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int? CaregiverId = null,
    int? TutorId = null
    );