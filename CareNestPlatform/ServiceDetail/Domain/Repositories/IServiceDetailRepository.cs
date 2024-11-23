using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.ServiceDetail.Domain.Repositories
{
    public interface IServiceDetailRepository
    {
        Task<WebApplication3.ServiceDetail.Domain.Model.Aggregates.ServiceDetail> GetByIdAsync(int id);
        Task<IEnumerable<WebApplication3.ServiceDetail.Domain.Model.Aggregates.ServiceDetail>> GetAllAsync();
        Task AddAsync(WebApplication3.ServiceDetail.Domain.Model.Aggregates.ServiceDetail serviceDetail);
        Task UpdateAsync(WebApplication3.ServiceDetail.Domain.Model.Aggregates.ServiceDetail serviceDetail);
        Task DeleteAsync(int id);
    }
}