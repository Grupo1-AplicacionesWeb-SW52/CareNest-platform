using CarNest.TutorPaymentMethod.Interfaces.ACL;
using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.Tutors.Domain.Model.Aggregates;

namespace CarNest.TutorPaymentMethod.Application.ACL;

public class TutorPaymentMethodContextFacade : ITutorPaymentMethodContextFacade
{
   private readonly IBaseRepository<Domain.Model.Aggregates.TutorPaymentMethod> _tutorPaymentMethodRepository;
   private readonly IBaseRepository<Tutor> _tutorRepository;

   public TutorPaymentMethodContextFacade(
      IBaseRepository<Domain.Model.Aggregates.TutorPaymentMethod> paymentMethodRepository,
      IBaseRepository<Tutor> tutorRepository)
   {
      _tutorPaymentMethodRepository = paymentMethodRepository;
      _tutorRepository = tutorRepository;
   }

   public async Task<int> CreateTutorPaymentMethodAsync(Domain.Model.Aggregates.TutorPaymentMethod tutorPaymentMethod)
   {
      {
         var tutor = await _tutorRepository.FindByIdAsync(tutorPaymentMethod.TutorId);
         if(tutor == null)
            throw new ArgumentException($"Tutor with ID {tutorPaymentMethod.TutorId} does not exits");
      }
      
      await _tutorPaymentMethodRepository.AddAsync(tutorPaymentMethod);
      return tutorPaymentMethod.Id;
   }

   public async Task<IEnumerable<Domain.Model.Aggregates.TutorPaymentMethod>> GetTutorPaymentMethodsByTutorAsync(int userId)
   {
      var tutor = await _tutorRepository.FindByIdAsync(userId);
      if(tutor == null)
         throw new ArgumentException($"Tutor with ID {userId} does not exits");
      return (await _tutorPaymentMethodRepository.ListAsync())
         .Where(pm => pm.TutorId == userId);
   }

   public async Task<bool> DeleteTutorPaymentMethodAsync(int tutorPaymentMethodId)
   {
      var tutorPaymentMethod = await _tutorPaymentMethodRepository.FindByIdAsync(tutorPaymentMethodId);
      if (tutorPaymentMethod == null) return false;
      
      _tutorPaymentMethodRepository.Remove(tutorPaymentMethod);
      return true;
   }

}