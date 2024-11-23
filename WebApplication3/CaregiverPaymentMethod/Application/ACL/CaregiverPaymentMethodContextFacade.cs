using WebApplication3.CaregiverPaymentMethod.Interfaces.ACL;
using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Shared.Domain.Repositories;

namespace WebApplication3.CaregiverPaymentMethod.Application.ACL;

public class CaregiverPaymentMethodContextFacade : IPaymentMethodContextFacade
{
    private readonly IBaseRepository<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod> _paymentMethodRepository;
    private readonly IBaseRepository<Caregiver> _caregiverRepository;

    public CaregiverPaymentMethodContextFacade(
        IBaseRepository<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod> paymentMethodRepository,
        IBaseRepository<Caregiver> caregiverRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _caregiverRepository = caregiverRepository;
    }

    public async Task<int> CreateCaregiverPaymentMethodAsync(CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod caregiverPaymentMethod)
    {
        {
            var caregiver = await _caregiverRepository.FindByIdAsync(caregiverPaymentMethod.CaregiverId);
            if (caregiver == null)
                throw new ArgumentException($"Caregiver with ID {caregiverPaymentMethod.CaregiverId} does not exits");
        }
        await _paymentMethodRepository.AddAsync(caregiverPaymentMethod);
        return caregiverPaymentMethod.Id;
    }

    public async Task<IEnumerable<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>> GetCaregiverPaymentMethodsByUserAsync(int caregiverId)
    {
            var caregiver = await _caregiverRepository.FindByIdAsync(caregiverId);
            if (caregiver == null)
                throw new ArgumentException($"Caregiver with ID {caregiverId} does not exits");
            return (await _paymentMethodRepository.ListAsync())
                .Where(pm => pm.CaregiverId == caregiverId);
    }

    public async Task<bool> DeleteCaregiverPaymentMethodAsync(int caregiverPaymentMethodId)
    {
        var paymentMethod = await _paymentMethodRepository.FindByIdAsync(caregiverPaymentMethodId);
        if (paymentMethod == null) return false;
        
        _paymentMethodRepository.Remove(paymentMethod);
        return true;
    }
}