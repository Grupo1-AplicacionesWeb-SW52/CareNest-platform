namespace WebApplication3.TutorPaymentMethod.Interfaces.ACL;

public interface ITutorPaymentMethodContextFacade
{
    Task<int> CreateTutorPaymentMethodAsync(Domain.Model.Aggregates.TutorPaymentMethod paymentMethod);
    Task<IEnumerable<Domain.Model.Aggregates.TutorPaymentMethod>> GetTutorPaymentMethodsByTutorAsync(int tutorId);
    Task<bool> DeleteTutorPaymentMethodAsync(int paymentMethodId);
}

