using CarNest.Reservations.Domain.Model.Aggregates;
using CarNest.Reservations.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Configuration;
using WebApplication3.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace CarNest.Reservations.Infrastructure.Persistence.EFC.Repositories{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context) { }

        public async Task<Reservation?> FindReservationByIdAsync(int id)
        {
            return await Context.Set<Reservation>().FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}