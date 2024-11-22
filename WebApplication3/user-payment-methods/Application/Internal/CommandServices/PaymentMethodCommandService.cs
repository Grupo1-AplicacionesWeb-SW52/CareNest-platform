using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Model.Commands;
using WebApplication3.user_payment_methods.Domain.Repositories;
using WebApplication3.user_payment_methods.Domain.Services;

namespace WebApplication3.user_payment_methods.Application.Internal.CommandServices;

public class PaymentMethodCommandService : IPaymentMethodCommandService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentMethodCommandService(IPaymentMethodRepository paymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserPaymentMethod?> Handle(CreateUserPaymentCommand command)
    {
        // Validate input
        if (string.IsNullOrEmpty(command.CardNumber) || string.IsNullOrEmpty(command.Cvv) || string.IsNullOrEmpty(command.CardHolder))
            throw new ArgumentException("Invalid payment method details.");

        // Ensure at least one associated entity
        if (command.CaregiverId == null && command.TutorId == null)
            throw new ArgumentException("A payment method must be associated with either a caregiver or a tutor.");

        // Create new UserPaymentMethod
        var paymentMethod = new UserPaymentMethod(
            command.CardNumber,
            command.ExpirationDate.ToString(),
            command.Cvv,
            command.CardHolder,
            command.CaregiverId,
            command.TutorId
        );

        // Add to repository and commit changes
        await _paymentMethodRepository.AddAsync(paymentMethod);
        await _unitOfWork.CompleteAsync();

        return paymentMethod;
    }
    
    public async Task<UserPaymentMethod?> Handle(UpdateUserPaymentCommand command)
    {
        // Find existing payment method
        var paymentMethod = await _paymentMethodRepository.FindPaymentMethodByIdAsync(command.Id);
        if (paymentMethod == null)
            throw new KeyNotFoundException("Payment method not found.");

        // Update properties
        paymentMethod.CardNumber = command.CardNumber;
        paymentMethod.ExpirationDate = command.ExpirationDate;
        paymentMethod.Cvv = command.Cvv;
        paymentMethod.CardHolder = command.CardHolder;

        // Update repository and commit changes
        _paymentMethodRepository.Update(paymentMethod);
        await _unitOfWork.CompleteAsync();

        return paymentMethod;
    }
}



























