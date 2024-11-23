using WebApplication3.CaregiverPaymentMethod.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WebApplication3.CaregiverPaymentMethod.Infrastructure.Persistence.EFC.Repositories;

public class CaregiverPaymentMethodRepository(AppDbContext context) :
    BaseRepository<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>(context), ICaregiverPaymentMethodRepository
{

    public async Task<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> FindCaregiverPaymentMethodByIdAsync(int id)
    {
        return Context.Set<CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>().FirstOrDefault(p => p.Id == id);
    }

}