using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Repositories;
using CarNest.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarNest.Reservations.Infrastructure.Persistence.EFC.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> ListAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation?> FindByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<IEnumerable<Reservation>> FindByStatusAsync(string status)
        {
            return await _context.Reservations
                .Where(r => r.Status.ToString() == status)
                .ToListAsync();
        }
        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}