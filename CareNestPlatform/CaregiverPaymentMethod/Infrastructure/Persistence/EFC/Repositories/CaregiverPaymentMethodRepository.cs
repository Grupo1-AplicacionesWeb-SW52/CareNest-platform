using CarNest.CaregiverPaymentMethod.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CarNest.CaregiverPaymentMethod.Infrastructure.Persistence.EFC.Repositories;

public class CaregiverPaymentMethodRepository(AppDbContext context) :
    BaseRepository<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>(context), ICaregiverPaymentMethodRepository
{

    public async Task<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod?> FindCaregiverPaymentMethodByIdAsync(int id)
    {
        return Context.Set<CarNest.CaregiverPaymentMethod.Domain.Model.Aggregates.CaregiverPaymentMethod>().FirstOrDefault(p => p.Id == id);
    }

}