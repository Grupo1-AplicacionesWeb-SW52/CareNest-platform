using Microsoft.EntityFrameworkCore;
using WebApplication3.Caregivers.Domain.Model.Aggregates;
using WebApplication3.Caregivers.Domain.Repositories;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WebApplication3.Caregivers.Infrastructure.Persistence.EFC.Repositories;

public class CaregiverRepository : ICaregiverRepository
{
    private readonly AppDbContext _context;

    public CaregiverRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Caregiver>> ListAsync()
    {
        return await _context.Caregivers.ToListAsync();
    }

    public async Task<Caregiver?> FindByIdAsync(int id)
    {
        return await _context.Caregivers.FindAsync(id);
    }

    public async Task AddAsync(Caregiver caregiver)
    {
        await _context.Caregivers.AddAsync(caregiver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Caregiver caregiver)
    {
        _context.Caregivers.Update(caregiver);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Caregiver caregiver)
    {
        _context.Caregivers.Remove(caregiver);
        await _context.SaveChangesAsync();
    }
}