using System.Threading.Tasks;
using WebApplication3.ServiceDetail.Domain.Model.Aggregates;
using WebApplication3.ServiceDetail.Domain.Repositories;

namespace WebApplication3.ServiceDetail.Application.Internal.CommandServices
{
    public class ServiceDetailCommandService
    {
        private readonly IServiceDetailRepository _repository;

        public ServiceDetailCommandService(IServiceDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateServiceDetail(ServiceDetail serviceDetail)
        {
            await _repository.AddAsync(serviceDetail);
        }

        public async Task UpdateServiceDetail(ServiceDetail serviceDetail)
        {
            await _repository.UpdateAsync(serviceDetail);
        }

        public async Task DeleteServiceDetail(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
