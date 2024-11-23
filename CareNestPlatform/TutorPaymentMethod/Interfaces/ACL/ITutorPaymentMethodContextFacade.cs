namespace CarNest.TutorPaymentMethod.Interfaces.ACL;

public interface ITutorPaymentMethodContextFacade
{
    Task<int> CreateTutorPaymentMethodAsync(CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod paymentMethod);
    Task<IEnumerable<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod>> GetTutorPaymentMethodsByTutorAsync(int tutorId);
    Task<bool> DeleteTutorPaymentMethodAsync(int paymentMethodId);
}

