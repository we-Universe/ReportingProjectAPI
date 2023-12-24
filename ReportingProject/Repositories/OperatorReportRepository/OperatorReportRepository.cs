using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.OperatorReportRepository
{
    public class OperatorReportRepository : IOperatorReportRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<OperatorReport> _dbSet;
        public OperatorReportRepository(ReportingDBContext reportingDBContex)
        {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<OperatorReport>();
        }
        public async Task UploadReportAsync(OperatorReport entity)
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

        public Task DeleteReportAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<OperatorReport>> GetAllReportsAsync()
        //{
        //    return await _dbSet.Include(report => report.ReportNotes).ToListAsync();
        //}

        public async Task<OperatorReport> GetReportByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("Operator Report not found");
        }

        public Task UpdateReportAsync(OperatorReport entity)
        {
            throw new NotImplementedException();
        }
    }
}