using ReportingProject.Data.Entities;
using ReportingProject.Repositories.ReportRepository;

namespace ReportingProject.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public Task UploadReportAsync(Report entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllReportsAsync();
        }

        public Task<Report> GetReportByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReportAsync(Report entity)
        {
            throw new NotImplementedException();
        }
    }
}