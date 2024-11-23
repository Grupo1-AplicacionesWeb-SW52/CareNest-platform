using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.TutorPaymentMethod.Domain.Model.Commands;
using WebApplication3.TutorPaymentMethod.Domain.Repositories;
using WebApplication3.TutorPaymentMethod.Domain.Services;

namespace WebApplication3.TutorPaymentMethod.Application.Internal.CommandServices;

public class TutorPaymentMethodCommandService : ITutorPaymentMethodCommandService
{
    private readonly ITutorPaymentMethodRepository _tutorPaymentMethodRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public TutorPaymentMethodCommandService(ITutorPaymentMethodRepository tutorPaymentMethodRepository, IUnitOfWork unitOfWork)
    {
        _tutorPaymentMethodRepository = tutorPaymentMethodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Model.Aggregates.TutorPaymentMethod?> Handle(CreateTutorPaymentMethodCommand command)
    {
        if (string.IsNullOrEmpty(command.CardNumber) || string.IsNullOrEmpty(command.Cvv) || string.IsNullOrEmpty(command.CardHolder))
            throw new ArgumentException("Invalid payment method details.");
        
        if (command.TutorId == null)
            throw new ArgumentException("A payment method must be associated with either a caregiver or a tutor.");

        var tutorPaymentMethod = new Domain.Model.Aggregates.TutorPaymentMethod(
            command.CardNumber,
            command.ExpirationDate.ToString(),
            command.Cvv,
            command.CardHolder,
            command.TutorId);
        
        await _tutorPaymentMethodRepository.AddAsync(tutorPaymentMethod);
        await _unitOfWork.CompleteAsync();

        return tutorPaymentMethod;

    }
    
    public async Task<Domain.Model.Aggregates.TutorPaymentMethod?> Handle(UpdateTutorPaymentMethodCommand command)
    {
        // Find existing payment method
        var paymentMethod = await _tutorPaymentMethodRepository.FindTutorPaymentMethodByIdAsync(command.Id);
        if (paymentMethod == null)
            throw new KeyNotFoundException("Payment method not found.");

        // Update properties
        paymentMethod.CardNumber = command.CardNumber;
        paymentMethod.ExpirationDate = command.ExpirationDate;
        paymentMethod.Cvv = command.Cvv;
        paymentMethod.CardHolder = command.CardHolder;

        // Update repository and commit changes
        _tutorPaymentMethodRepository.Update(paymentMethod);
        await _unitOfWork.CompleteAsync();

        return paymentMethod;
    }
}