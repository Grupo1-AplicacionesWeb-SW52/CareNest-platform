using CareNestPlatform.Caregivers.Domain.Model.Aggregates;
using CareNestPlatform.Shared.Domain.Repositories;
using CareNestPlatform.Tutors.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Interfaces.ACL;

namespace CareNestPlatform.Payments.Application.ACL;

public class PaymentContextFacade : IPaymentContextFacade
{
    private readonly IBaseRepository<Payment> _paymentRepository;
    private readonly IBaseRepository<Tutor> _tutorRepository;
    private readonly IBaseRepository<Caregiver> _caregiverRepository;

    public PaymentContextFacade(
        IBaseRepository<Payment> paymentRepository,
        IBaseRepository<Tutor> tutorRepository,
        IBaseRepository<Caregiver> caregiverRepository)
    {
        _paymentRepository = paymentRepository;
        _tutorRepository = tutorRepository;
        _caregiverRepository = caregiverRepository;
    }

    public async Task<int> CreatePaymentAsync(Payment payment)
    {
        if (payment.CaregiverId.HasValue)
        {
            var caregiver = await _caregiverRepository.FindByIdAsync(payment.CaregiverId.Value);
            if (caregiver == null)
                throw new ArgumentException($"Caregiver with ID {payment.CaregiverId} does not exist.");
        }

        if (payment.TutorId.HasValue)
        {
            var tutor = await _tutorRepository.FindByIdAsync(payment.TutorId.Value);
            if (tutor == null)
                throw new ArgumentException($"Tutor with ID {payment.TutorId} does not exist.");
        }

        await _paymentRepository.AddAsync(payment);
        return payment.Id;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByUserAsync(int userId, string userType)
    {
        if (userType == "caregiver")
        {
            var caregiver = await _caregiverRepository.FindByIdAsync(userId);
            if (caregiver == null)
                throw new ArgumentException($"Caregiver with ID {userId} does not exist.");
            return (await _paymentRepository.ListAsync())
                .Where(pm => pm.CaregiverId == userId);
        }

        if (userType == "tutor")
        {
            var tutor = await _tutorRepository.FindByIdAsync(userId);
            if (tutor == null)
                throw new ArgumentException($"Tutor with ID {userId} does not exist.");
            return (await _paymentRepository.ListAsync())
                .Where(pm => pm.TutorId == userId);
        }

        throw new ArgumentException("Invalid user type. Use 'tutor' or 'caregiver'.");
    }

    public async Task<bool> DeletePaymentAsync(int paymentId)
    {
        var payment = await _paymentRepository.FindByIdAsync(paymentId);
        if (payment == null) return false;
        
        _paymentRepository.Remove(payment);
        return true;
    }
}
