using ReportingProject.Repositories.ServiceRepository;

namespace ReportingProject.Services.ServiceService
{
	public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<int> GetServiceIdFromServiceNameAsync(string name)
        {
            int serviceId = await _serviceRepository.GetServiceIdFromServiceNameAsync(name);
            return serviceId;
        }

        public async Task<decimal> GetClientShareFromServiceNameAsync(string name)
        {
            decimal clientShare = await _serviceRepository.GetClientShareFromServiceNameAsync(name);
            return clientShare;
        }
    }
}