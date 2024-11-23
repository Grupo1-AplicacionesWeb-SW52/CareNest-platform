using Microsoft.EntityFrameworkCore;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;
using WebApplication3.Payments.Domain.Model.Aggregates;
using WebApplication3.Payments.Domain.Repositories;

namespace WebApplication3.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context) :
    BaseRepository<Payment>(context), IPaymentRepository
{

    public async Task<Payment?> FindPaymentByIdAsync(int id)
    {
        return await Context.Set<Payment>().FirstOrDefaultAsync(p => p.Id == id); // Fetch a payment by ID
    }
}