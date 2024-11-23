namespace WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Resources;

public record UpdatePaymentMethodResource(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int CaregiverId
    );