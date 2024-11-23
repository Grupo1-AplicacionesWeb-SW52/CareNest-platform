using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.Tutors.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Interfaces.ACL;

namespace WebApplication3.user_payment_methods.Application.ACL;

public class PaymentMethodContextFacade : IPaymentMethodContextFacade
{
    private readonly IBaseRepository<Domain.Model.Aggregates.TutorPaymentMethod> _paymentMethodRepository;
    private readonly IBaseRepository<Tutor> _tutorRepository;
    private readonly IBaseRepository<Caregiver> _caregiverRepository;

    public PaymentMethodContextFacade(
        IBaseRepository<Domain.Model.Aggregates.TutorPaymentMethod> paymentMethodRepository,
        IBaseRepository<Tutor> tutorRepository,
        IBaseRepository<Caregiver> caregiverRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _tutorRepository = tutorRepository;
        _caregiverRepository = caregiverRepository;
    }

    public async Task<int> CreatePaymentMethodAsync(Domain.Model.Aggregates.TutorPaymentMethod paymentMethod)
    {
        if (paymentMethod.CaregiverId.HasValue)
        {
            var caregiver = await _caregiverRepository.FindByIdAsync(paymentMethod.CaregiverId.Value);
            if (caregiver == null)
                throw new ArgumentException($"Caregiver with ID {paymentMethod.CaregiverId} does not exits");
        }

        if (paymentMethod.TutorId.HasValue)
        {
            var tutor = await _tutorRepository.FindByIdAsync(paymentMethod.TutorId.Value);
            if (tutor == null)
                throw new ArgumentException($"Tutor with ID {paymentMethod.TutorId} does not exits");
        }

        await _paymentMethodRepository.AddAsync(paymentMethod);
        return paymentMethod.Id;
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.TutorPaymentMethod>> GetPaymentMethodsByUserAsync(int userId, string userType)
    {
        if (userType == "caregiver")
        {
            var caregiver = await _caregiverRepository.FindByIdAsync(userId);
            if (caregiver == null)
                throw new ArgumentException($"Caregiver with ID {userId} does not exits");
            return (await _paymentMethodRepository.ListAsync())
                .Where(pm => pm.CaregiverId == userId);
        }

        if (userType == "tutor")
        {
            var tutor = await _tutorRepository.FindByIdAsync(userId);
            if (tutor == null)
                throw new ArgumentException($"Tutor con ID {userId} no existe.");
            return (await _paymentMethodRepository.ListAsync())
                .Where(pm => pm.TutorId == userId);
        }

        throw new ArgumentException("Invalid user type. Use 'tutor' o 'caregiver'. ");
    }

    public async Task<bool> DeletePaymentMethodAsync(int paymentMethodId)
    {
        var paymentMethod = await _paymentMethodRepository.FindByIdAsync(paymentMethodId);
        if (paymentMethod == null) return false;
        
        _paymentMethodRepository.Remove(paymentMethod);
        return true;
    }
    
}
































