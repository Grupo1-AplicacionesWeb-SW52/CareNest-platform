namespace WebApplication3.user_payment_methods.Domain.Model.Commands;

public record CreateUserPaymentCommand(
    int UserId,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder
    );