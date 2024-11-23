using Microsoft.EntityFrameworkCore;
using CareNestPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using CareNestPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using CareNestPlatform.Payments.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Domain.Repositories;

namespace WebApplication3.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context) :
    BaseRepository<Payment>(context), IPaymentRepository
{

    public async Task<Payment?> FindPaymentByIdAsync(int id)
    {
        return await Context.Set<Payment>().FirstOrDefaultAsync(p => p.Id == id); // Fetch a payment by ID
    }
}