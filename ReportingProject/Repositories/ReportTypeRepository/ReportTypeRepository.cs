using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ReportTypeRepository
{
    public class ReportTypeRepository : IReportTypeRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<ReportType> _dbSet;
        public ReportTypeRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<ReportType>();
        }
        public Task AddReportTypeAsync(ReportType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReportType>> GetAllReportsTypesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ReportType> GetReportTypeByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("Report not found");
        }

        public Task UpdateReportTypeAsync(ReportType entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetReportTypeIdFromNameAsync(string name)
        {
            var reportType = await _dbSet.FirstOrDefaultAsync(rt => rt.Name == name);
            return reportType == null ? throw new Exception("ReportType not found") : reportType.Id;
        }
    }
}