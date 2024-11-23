namespace CarNest.TutorPaymentMethod.Interfaces.REST.Resources;

public record TutorPaymentMethodResource(
    int Id,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int TutorId 
    );