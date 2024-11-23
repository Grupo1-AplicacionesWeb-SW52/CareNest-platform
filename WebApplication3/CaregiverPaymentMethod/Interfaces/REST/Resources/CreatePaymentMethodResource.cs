namespace WebApplication3.CaregiverPaymentMethod.Interfaces.REST.Resources;

public record CreatePaymentMethodResource(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int CaregiverId
    );