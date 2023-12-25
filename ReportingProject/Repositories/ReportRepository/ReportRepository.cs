using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.ReportRepository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportingDBContext _reportingDBContext;
        private readonly DbSet<Report> _dbSet;

        public ReportRepository(ReportingDBContext reportingDBContex) {
            _reportingDBContext = reportingDBContex;
            _dbSet = _reportingDBContext.Set<Report>();
        }

        public async Task UploadReportAsync(Report entity)
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

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _dbSet.Include(report=>report.ReportNotes).ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception("Report not found");
        }

        public Task UpdateReportAsync(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}