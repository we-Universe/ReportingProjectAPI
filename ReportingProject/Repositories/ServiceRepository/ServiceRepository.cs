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

        public async Task<decimal> GetClientShareFromServiceNameAsync(string name)
        {
            var clientShare = await _dbSet
                .Where(rt => rt.Name == name)
                .Select(rt => rt.Contract.ClientShare)
                .FirstOrDefaultAsync();

            return clientShare;
        }

        public async Task<bool> IsOutsidePalestineAsync(string name)
        {
            var isOutsidePalestine = await _dbSet
                .Where(rt => rt.Name == name)
                .Select(rt => rt.ServiceOperators
                    .Any(so => so.Operator.Company.Country.Name != "Palestine"))
                .FirstOrDefaultAsync();

            return isOutsidePalestine;
        }

        public async Task<decimal> GetPNAValueFromServiceNameAsync(string name)
        {
            var npa = await _dbSet
                .Where(s => s.Name == name)
                .SelectMany(s => s.ServiceOperators)
                .Select(so => so.Operator.PNAValue)
                .FirstOrDefaultAsync();
             
            return npa;
        }





    }
}