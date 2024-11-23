using WebApplication3.Shared.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}