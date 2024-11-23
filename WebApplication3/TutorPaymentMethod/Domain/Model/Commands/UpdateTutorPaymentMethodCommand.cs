namespace WebApplication3.TutorPaymentMethod.Domain.Model.Commands;

public record UpdateTutorPaymentMethodCommand(
    int Id,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int TutorId 
    );