namespace WebApplication3.TutorPaymentMethod.Interfaces.REST.Resources;

public record CreateTutorPaymentMethodResource(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int TutorId 
    );