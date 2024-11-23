namespace CarNest.CaregiverPaymentMethod.Domain.Model.Commands;

public record CreateCaregiverPaymentCommand(
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int CaregiverId 
    );