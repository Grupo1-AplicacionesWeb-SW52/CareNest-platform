namespace CarNest.TutorPaymentMethod.Interfaces.REST.Resources;

public record UpdateTutorPaymentMethodResource(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int TutorId 
    );