namespace WebApplication3.CaregiverPaymentMethod.Interfaces.ACL;

public interface IPaymentMethodContextFacade
{
    Task<int> CreateCaregiverPaymentMethodAsync(CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod caregiverPaymentMethod);
    
    Task<IEnumerable<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>> GetCaregiverPaymentMethodsByUserAsync(int caregiverId);

    Task<bool> DeleteCaregiverPaymentMethodAsync(int caregiverPaymentMethodId);

}