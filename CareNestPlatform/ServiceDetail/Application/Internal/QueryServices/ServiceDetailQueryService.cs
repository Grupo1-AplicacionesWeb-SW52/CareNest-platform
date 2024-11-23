using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.ServiceDetail.Domain.Repositories;

namespace WebApplication3.ServiceDetail.Application.Internal.QueryServices
{
    public class ServiceDetailQueryService
    {
        private readonly IServiceDetailRepository _repository;

        public ServiceDetailQueryService(IServiceDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WebApplication3.ServiceDetail.Domain.Model.Aggregates.ServiceDetail>> GetAllServiceDetails()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<WebApplication3.ServiceDetail.Domain.Model.Aggregates.ServiceDetail> GetServiceDetailById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}