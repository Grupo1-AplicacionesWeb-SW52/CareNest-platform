using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.ServiceDetail.Domain.Model.Aggregates;
using WebApplication3.ServiceDetail.Domain.Repositories;

namespace WebApplication3.ServiceDetail.Infrastructure.Persistence.Repositories
{
    public class ServiceDetailRepository : IServiceDetailRepository
    {
        private readonly AppDbContext _context;

        public ServiceDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceDetail> GetByIdAsync(int id)
        {
            return await _context.ServiceDetails.FindAsync(id);
        }

        public async Task<IEnumerable<ServiceDetail>> GetAllAsync()
        {
            return await _context.ServiceDetails.ToListAsync();
        }

        public async Task AddAsync(ServiceDetail serviceDetail)
        {
            await _context.ServiceDetails.AddAsync(serviceDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceDetail serviceDetail)
        {
            _context.ServiceDetails.Update(serviceDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var serviceDetail = await _context.ServiceDetails.FindAsync(id);
            if (serviceDetail != null)
            {
                _context.ServiceDetails.Remove(serviceDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
