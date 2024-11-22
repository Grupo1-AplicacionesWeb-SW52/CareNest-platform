using Microsoft.EntityFrameworkCore;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;
using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Repositories;

namespace WebApplication3.user_payment_methods.Infrastructure.Persistence.EFC.Repositories;

public class PaymentMethodRepository(AppDbContext context) :
    BaseRepository<UserPaymentMethod>(context), IPaymentMethodRepository
{

    public async Task<UserPaymentMethod?> FindPaymentMethodByIdAsync(int id)
    {
        return Context.Set<UserPaymentMethod>().FirstOrDefault(p => p.Id == id);
    }

}