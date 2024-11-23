using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.Payments.Domain.Model.Aggregates;
using WebApplication3.Payments.Domain.Model.Commands;
using WebApplication3.Payments.Domain.Repositories;
using WebApplication3.Payments.Domain.Services;

namespace WebApplication3.Payments.Application.Internal.CommandServices;

public class PaymentCommandService : IPaymentCommandService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        // Validate input
        if (string.IsNullOrEmpty(command.CardNumber) || string.IsNullOrEmpty(command.Type) || command.Amount <= 0)
            throw new ArgumentException("Invalid payment details.");

        // Ensure at least one associated entity (Caregiver or Tutor)
        if (command.CaregiverId == null && command.TutorId == null)
            throw new ArgumentException("A payment must be associated with either a caregiver or a tutor.");

        // Create new Payment
        var payment = new Payment(
            command.CardNumber,
            command.CreatedAt,
            command.Type,
            command.Amount,
            command.CaregiverId,
            command.TutorId
        );

        // Add to repository and commit changes
        await _paymentRepository.AddAsync(payment);
        await _unitOfWork.CompleteAsync();

        return payment;
    }
    
    public async Task<Payment?> Handle(UpdatePaymentCommand command)
    {
        // Find existing payment
        var payment = await _paymentRepository.FindPaymentByIdAsync(command.Id);
        if (payment == null)
            throw new KeyNotFoundException("Payment not found.");

        // Update properties
        payment.CardNumber = command.CardNumber;
        payment.CreatedAt = command.CreatedAt;
        payment.Type = command.Type;
        payment.Amount = command.Amount;

        // Update repository and commit changes
        _paymentRepository.Update(payment);
        await _unitOfWork.CompleteAsync();

        return payment;
    }
}
