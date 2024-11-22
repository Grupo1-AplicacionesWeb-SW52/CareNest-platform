namespace WebApplication3.user_payment_methods.Interfaces.REST.Resources;

public record CreatePaymentMethodResource(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int? CaregiverId = null,
    int? TutorId = null
    );