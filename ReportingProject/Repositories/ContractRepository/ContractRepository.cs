using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ContractRepository
{
	public class ContractRepository : IContractRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Contract> _dbSet;


        public ContractRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<Contract>();
        }

        public async Task UploadContractAsync(Contract entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _reportingDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving changes to the database.", ex);
            }
        }
    }
}