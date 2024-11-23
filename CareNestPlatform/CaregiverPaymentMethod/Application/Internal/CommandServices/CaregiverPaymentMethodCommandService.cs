using CarNest.CaregiverPaymentMethod.Domain.Model.Commands;
using CarNest.CaregiverPaymentMethod.Domain.Repositories;
using CarNest.CaregiverPaymentMethod.Domain.Services;
using WebApplication3.Shared.Domain.Repositories;

namespace CarNest.CaregiverPaymentMethod.Application.Internal.CommandServices;

public class CaregiverPaymentMethodCommandService : ICaregiverPaymentMethodCommandService
{
    private readonly ICaregiverPaymentMethodRepository _caregiverPaymentMethodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CaregiverPaymentMethodCommandService(ICaregiverPaymentMethodRepository caregiverPaymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _caregiverPaymentMethodRepository = caregiverPaymentMethodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(CreateCaregiverPaymentCommand command)
    {
        // Validate input
        if (string.IsNullOrEmpty(command.CardNumber) || string.IsNullOrEmpty(command.Cvv) || string.IsNullOrEmpty(command.CardHolder))
            throw new ArgumentException("Invalid payment method details.");
        
        // Create new UserPaymentMethod
        var paymentMethod = new Domain.Model.Aggregates.CaregiverPaymentMethod(
            command.CardNumber,
            command.ExpirationDate.ToString(),
            command.Cvv,
            command.CardHolder,
            command.CaregiverId
        );

        // Add to repository and commit changes
        await _caregiverPaymentMethodRepository.AddAsync(paymentMethod);
        await _unitOfWork.CompleteAsync();

        return paymentMethod;
    }
    
    public async Task<Domain.Model.Aggregates.CaregiverPaymentMethod?> Handle(UpdateCaregiverPaymentCommand command)
    {
        // Find existing payment method
        var paymentMethod = await _caregiverPaymentMethodRepository.FindCaregiverPaymentMethodByIdAsync(command.Id);
        if (paymentMethod == null)
            throw new KeyNotFoundException("Payment method not found.");

        // Update properties
        paymentMethod.CardNumber = command.CardNumber;
        paymentMethod.ExpirationDate = command.ExpirationDate;
        paymentMethod.Cvv = command.Cvv;
        paymentMethod.CardHolder = command.CardHolder;

        // Update repository and commit changes
        _caregiverPaymentMethodRepository.Update(paymentMethod);
        await _unitOfWork.CompleteAsync();

        return paymentMethod;
    }
}



























