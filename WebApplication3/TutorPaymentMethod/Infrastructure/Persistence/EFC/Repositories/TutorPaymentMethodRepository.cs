using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;
using WebApplication3.TutorPaymentMethod.Domain.Repositories;

namespace WebApplication3.TutorPaymentMethod.Infrastructure.Persistence.EFC.Repositories;

public class TutorPaymentMethodRepository(AppDbContext context): 
    BaseRepository<Domain.Model.Aggregates.TutorPaymentMethod>(context), ITutorPaymentMethodRepository
    
{
    public async Task<Domain.Model.Aggregates.TutorPaymentMethod?> FindTutorPaymentMethodByIdAsync(int id)
    {
        return Context.Set<Domain.Model.Aggregates.TutorPaymentMethod>().FirstOrDefault(p => p.Id == id);
    }
}