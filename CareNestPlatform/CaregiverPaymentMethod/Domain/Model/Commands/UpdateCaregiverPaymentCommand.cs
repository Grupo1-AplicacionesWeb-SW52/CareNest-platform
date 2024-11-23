namespace CarNest.CaregiverPaymentMethod.Domain.Model.Commands;

public record UpdateCaregiverPaymentCommand(
    int Id,
    string CardNumber,
    DateTime ExpirationDate,
    string Cvv,
    string CardHolder,
    int CaregiverId 
    );