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
            var service = await _dbSet.FirstOrDefaultAsync(rt => rt.Name == name);
            return service == null ? throw new Exception("Service not found") : service.Id;
        }

        public async Task<decimal> GetClientShareFromServiceNameAsync(string name)
        {
            var clientShare = await _dbSet
                .Where(rt => rt.Name == name)
                .Select(rt => rt.Contract.ClientShare)
                .FirstOrDefaultAsync();

            return clientShare;
        }

        public async Task<string> GetOperatorCountryFromServiceNameAsync(string name)
        {
            var operatorCountry = await _dbSet
                .Where(rt => rt.Name == name)
                .Select(rt => rt.ServiceOperators
                    .Select(so => so.Operator.Company.Country.Name)
                    .FirstOrDefault())
                .FirstOrDefaultAsync();

            return operatorCountry;
        }

        public async Task<string> GetMerchantNameFromServiceNameAsync(string name)
        {
            var companyName = await _dbSet
                .Where(service => service.Name == name)
                .Select(service => service.Contract.Merchant.Consultant.Client.Company.Name)
                .FirstOrDefaultAsync();

            return companyName;
        }

        public async Task<decimal> GetConsultantShareFromServiceNameAsync(string name)
        {
            var service = await _dbSet.FirstOrDefaultAsync(rt => rt.Name == name);
            return service == null ? throw new Exception("Service not found") : service.ConsultantShare;
        }

        public async Task<decimal> GetNonResidentialValueFromServiceName(string name)
        {
            var nonResidentialValue = await _dbSet
                .Where(s => s.Name == name)
                .SelectMany(s => s.ServiceOperators)
                .Select(so => so.Operator.NonResidentialValue)
                .FirstOrDefaultAsync();

            return nonResidentialValue;
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