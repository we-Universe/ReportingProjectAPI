using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.RevenueRepository
{
	public class RevenueRepository : IRevenueRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Revenue> _dbSet;


        public RevenueRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<Revenue>();
        }

        public async Task UploadRevenueAsync(Revenue entity)
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

