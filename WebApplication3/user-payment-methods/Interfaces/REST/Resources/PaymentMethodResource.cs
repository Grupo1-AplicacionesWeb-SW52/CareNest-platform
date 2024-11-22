namespace WebApplication3.user_payment_methods.Interfaces.REST.Resources;

public record PaymentMethodResource(
    int Id,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int? CaregiverId = null,
    int? TutorId = null
    );
