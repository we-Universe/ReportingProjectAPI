using ReportingProject.Data.Entities;
using ReportingProject.Repositories.OperatorReportRepository;

namespace ReportingProject.Services.OperatorReportService
{
	public class OperatorReportService : IOperatorReportService
    {
        private readonly IOperatorReportRepository _reportRepository;

        public OperatorReportService(IOperatorReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public Task UploadReportAsync(OperatorReport entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReportAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OperatorReport>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllReportsAsync();
        }

        public Task<OperatorReport> GetReportByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReportAsync(OperatorReport entity)
        {
            throw new NotImplementedException();
        }
    }
}