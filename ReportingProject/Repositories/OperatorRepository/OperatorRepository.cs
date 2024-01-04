using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.OperatorRepository
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Operator> _dbSet;

        public OperatorRepository(ReportingDBContext reportingDBContext)
        {
            _reportingDBContext = reportingDBContext;
            _dbSet = _reportingDBContext.Set<Operator>();
        }

        public async Task<int> GetOperatorIdByCompanyNameAsync(string companyName)
        {
            try
            {
                var operatorEntity = await _dbSet
                    .Include(o => o.Company)
                    .FirstOrDefaultAsync(o => o.Company.Name == companyName);

                if (operatorEntity == null || operatorEntity.Company == null)
                {
                    throw new Exception("Company not found");
                }

                return operatorEntity.Company.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}