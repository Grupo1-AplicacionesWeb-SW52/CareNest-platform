using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.ServiceDetail.Domain.Model.Aggregates;

namespace WebApplication3.ServiceDetail.Domain.Repositories
{
    public interface IServiceDetailRepository
    {
        Task<ServiceDetail> GetByIdAsync(int id);
        Task<IEnumerable<ServiceDetail>> GetAllAsync();
        Task AddAsync(ServiceDetail serviceDetail);
        Task UpdateAsync(ServiceDetail serviceDetail);
        Task DeleteAsync(int id);
    }
}
