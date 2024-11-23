using Microsoft.EntityFrameworkCore;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Tutors.Domain.Model.Aggregates;
using WebApplication3.Tutors.Domain.Repositories;

namespace WebApplication3.Tutors.Infrastructure.Persistence.EFC.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Tutor tutor)
    {
        await _context.Tutors.AddAsync(tutor);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Tutor tutor)
    {
        _context.Tutors.Remove(tutor);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tutor>> ListAsync()
    {
        return await _context.Tutors.ToListAsync();
    }

    public async Task<Tutor?> FindByIdAsync(int id)
    {
        return await _context.Tutors.FindAsync(id);
    }

    public async Task UpdateAsync(Tutor tutor)
    {
        _context.Tutors.Update(tutor);
        await _context.SaveChangesAsync();
    }
}
