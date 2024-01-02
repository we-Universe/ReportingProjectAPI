using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ServiceRepository
{
	public class ServiceRepository : IServiceRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Service> _dbSet;

        public ServiceRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<Service>();
        }

        public async Task<int> GetServiceIdFromServiceNameAsync(string name)
        {
            var serviceId = await _dbSet.FirstOrDefaultAsync(rt => rt.Name == name);
            return serviceId == null ? throw new Exception("Service not found") : serviceId.Id;
        }
    }
}