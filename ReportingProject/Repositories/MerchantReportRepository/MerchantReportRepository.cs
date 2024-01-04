using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;
using ReportingProject.Data.Resources;

namespace ReportingProject.Repositories.MerchantReportRepository
{
	public class MerchantReportRepository : IMerchantReportRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<MerchantReport> _dbSet;
        public MerchantReportRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<MerchantReport>();
        }

        public async Task<IEnumerable<MerchantReport>> GetAllMerchantsReports()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<MerchantReportExcelResource>> GetDetailsDataForGeneratedMerchantReport(int merchantId, int month, int year)
        {
            List<MerchantReportExcelResource> result = new();
            try
            {
                result = await (
                from merchant in _reportingDBContext.Merchants
                where merchant.Id == merchantId
                join contract in _reportingDBContext.Contracts on merchant.Id equals contract.MerchantId into contractGroup
                from contract in contractGroup.DefaultIfEmpty()
                join service in _reportingDBContext.Services on contract.Id equals service.ContractId into serviceGroup
                from service in serviceGroup.DefaultIfEmpty()
                join serviceType in _reportingDBContext.ServiceTypes on service.ServiceTypeId equals serviceType.Id into serviceTypeGroup
                from serviceType in serviceTypeGroup.DefaultIfEmpty()
                join serviceOperator in _reportingDBContext.ServiceOperators on service.Id equals serviceOperator.ServiceId into serviceOperatorGroup
                from serviceOperator in serviceOperatorGroup.DefaultIfEmpty()
                join revenue in _reportingDBContext.Revenues on serviceOperator.Id equals revenue.ServiceOperatorId into revenueGroup//
                from revenue in revenueGroup.DefaultIfEmpty()
                where revenue.Year == year && revenue.Month == month
                join operrator in _reportingDBContext.Operators on serviceOperator.OperatorId equals operrator.Id into operatorGroup
                from operrator in operatorGroup.DefaultIfEmpty()
                join company in _reportingDBContext.Companies on operrator.CompanyId equals company.Id into companyGroup
                from company in companyGroup.DefaultIfEmpty()
                join currency in _reportingDBContext.Currencies on company.CurrencyId equals currency.Id into currencyGroup
                from currency in currencyGroup.DefaultIfEmpty()
                join client in _reportingDBContext.Clients on company.Id equals client.CompanyId into clientGroup
                from client in clientGroup.DefaultIfEmpty()
                join country in _reportingDBContext.Countries on company.CountryId equals country.Id into countryGroup
                from country in countryGroup.DefaultIfEmpty()
                select new MerchantReportExcelResource
                {
                    Merchant = merchant,
                    Contract = contract,
                    Service = service,
                    ServiceType = serviceType,
                    ServiceOperator = serviceOperator,
                    Revenue = revenue,
                    Operator = operrator,
                    Company = company,
                    Currency = currency,
                    Client = client,
                    Country = country,
                })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return result;

            }
            return result;
        }
    }
}