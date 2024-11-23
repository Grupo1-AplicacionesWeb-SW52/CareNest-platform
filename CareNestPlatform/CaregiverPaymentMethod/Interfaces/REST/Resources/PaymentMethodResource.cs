namespace CarNest.CaregiverPaymentMethod.Interfaces.REST.Resources;

public record PaymentMethodResource(
    int Id,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int CaregiverId
    );
