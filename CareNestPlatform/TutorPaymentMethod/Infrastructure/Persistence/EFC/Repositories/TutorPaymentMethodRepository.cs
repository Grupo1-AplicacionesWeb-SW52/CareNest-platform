using CarNest.TutorPaymentMethod.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CarNest.TutorPaymentMethod.Infrastructure.Persistence.EFC.Repositories;

public class TutorPaymentMethodRepository(AppDbContext context): 
    BaseRepository<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod>(context), ITutorPaymentMethodRepository
    
{
    public async Task<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod?> FindTutorPaymentMethodByIdAsync(int id)
    {
        return Context.Set<CarNest.TutorPaymentMethod.Domain.Model.Aggregates.TutorPaymentMethod>().FirstOrDefault(p => p.Id == id);
    }
}