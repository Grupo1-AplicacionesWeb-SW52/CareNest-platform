namespace CarNest.TutorPaymentMethod.Domain.Model.Commands;

public record CreateTutorPaymentMethodCommand(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int TutorId
    );