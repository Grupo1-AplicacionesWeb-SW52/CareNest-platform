namespace CarNest.CaregiverPaymentMethod.Interfaces.ACL;

public interface IPaymentMethodContextFacade
{
    Task<int> CreateCaregiverPaymentMethodAsync(CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod caregiverPaymentMethod);
    
    Task<IEnumerable<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>> GetCaregiverPaymentMethodsByUserAsync(int caregiverId);

    Task<bool> DeleteCaregiverPaymentMethodAsync(int caregiverPaymentMethodId);

}